<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="DashBoard2.aspx.cs" Inherits="DashBoard2" %>
<%--<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagPrefix="uc1" TagName="DashboardMenuBar" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
   <%--   <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>--%>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }


        
        .mapouterdiv {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<%--   <uc1:DashboardMenuBar runat="server" ID="DashboardMenuBar" />--%>
     <br />
       <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-3">	
        <table width="70%">
       <tr>
       
       <td>
      Todays Status: <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        
  <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" />
           <asp:Button ID="Butshow" runat="server"  Text="show" onclick="Butshow_Click" class="btn btn-primary"/>
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server"  PopupButtonID="imgdate1" TargetControlID="txtFrom">                
    </ajaxtoolkit:calendarextender>
            <br />
    <br />
           <asp:Button ID="ButPreOperation" runat="server" Text="PreOperation" 
               onclick="ButPreOperation_Click" Visible="false"  />
            <asp:Button ID="ButPostOperation" runat="server" Text="PostOperation" 
               onclick="ButPostOperation_Click"  Visible="false" />
           <br />
             <asp:Label ID="lblIndent" runat="server" Text="Select  Indent:" Visible="false" ></asp:Label>  
           <asp:DropDownList ID="ddl_Indent" runat="server" AutoPostBack="True" Width="140px" OnSelectedIndexChanged ="ddl_Indent_SelectedIndexChanged" Visible="false">
           </asp:DropDownList>
           <br />
           <br />
            <asp:RadioButton ID="radPreOperation" runat="server" Text="PreOperation" GroupName="a"  />
           <asp:RadioButton ID="radPostOperation" runat="server"  Checked="true" Text="PostOperation" GroupName="a"  />
            <asp:RadioButton ID="radpending" runat="server" Text="Pending Indents" GroupName="a"  />
           <br />
           <br />
           <a href="MyTripplan.aspx">
           <asp:Label ID="Lbladposted" runat="server" Font-Bold="true" ForeColor="blue" Text="No of ADs Posted" Visible="false" Font-Underline="true" Font-Underline-color="blue" ></asp:Label>
           </a>
           &nbsp;
         <a href="RoutePrice.aspx">  <asp:Label ID="lblQuotesReceived" runat="server" Font-Bold="true" ForeColor="blue" Text="No of Quotes Received" Font-Underline="true" Font-color="blue" Visible="false"></asp:Label> </a> 
           &nbsp;
           <asp:Label ID="lblLowestQuote" runat="server" Font-Bold="true" ForeColor="blue" Text="Lowest Quote" Visible="false"></asp:Label>
           &nbsp;
         <a href="#">   <asp:Label ID="lblsaving" runat="server" Font-Bold="true" ForeColor="blue" Text="Estimated Savings" Font-Underline="true" Font-color="blue" Visible="false"></asp:Label></a> 
           <br />
  
           <asp:Label ID="lbl_Project" runat ="server" Text ="Project :"></asp:Label>
           &nbsp;<asp:DropDownList ID="ddl_Projects" runat="server" AutoPostBack="True" Width="280px" OnSelectedIndexChanged ="ddl_Projects_SelectedIndexChanged">
           </asp:DropDownList>
           <br />
           <br />
            <div class ="mapouterdiv" >

           
       <center >
           <asp:Label ID="lblHeading" runat="server" Text="Pre-Operation Dashboad" 
               Font-Names="Arial" Font-Size="12pt" ForeColor="Red"></asp:Label>
    
    
    
   <asp:GridView ID="GridSummary" runat="server" AutoGenerateColumns="False"  OnRowDataBound="GridSummary_RowDataBound"
        CellPadding="4" ForeColor="#333333">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="ToLocation" HeaderText="Address" />
            <asp:BoundField DataField="City" HeaderText="Location" />
            
            <asp:BoundField DataField="Quotes" HeaderText="No of Quotes" />
            <asp:TemplateField HeaderText="QuoteDetails">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnkDetails" runat="server"  style="color:blue;text-decoration:underline"  NavigateUrl=<%# String.Format("javascript:void(window.open('DashboardDetails.aspx?PostID={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("PostID")) %>>View</asp:HyperLink>
                       <asp:Label ID="lblpostid" runat="server" Text ='<%#Eval("PostID")%>' ForeColor="White"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="EarlierQuote" Visible="True" >
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="EarlierQuote" runat="server" Text ='<%#Eval("EarlierQuote")%>' ></asp:Label>
           
                <%-- <asp:BoundField DataField="EarlierQuote" HeaderText="" />--%>
                </ItemTemplate>
            </asp:TemplateField>
            
            
            
             <asp:TemplateField HeaderText="TodaysL1Quote">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTodayQuote" runat="server" Text ='<%#Eval("TodayL1Quote")%>'></asp:Label>
           
                <%-- <asp:BoundField DataField="EarlierQuote" HeaderText="" />--%>
                </ItemTemplate>
            </asp:TemplateField>
            
 <%--     
     <asp:BoundField DataField="TodayL1Quote" HeaderText="TodaysL1Quote" />--%>
     <asp:BoundField DataField="Difference" HeaderText="Difference" Visible="True" />
     
       
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <%--  <asp:GridView ID="GridViewPostOperation" runat="server" AutoGenerateColumns="false"  
        CellPadding="4" ForeColor="#333333" Visible="false" >
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns >
         <asp:BoundField DataField="ProjectNo" HeaderText="ProjectNo" />
         <asp:TemplateField HeaderText="ProjectNo" Visible="False">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("ProjectNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProjectNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
          <asp:TemplateField HeaderText="CNGenerated">
                <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnkDetails" runat="server" Text='<%# Bind("CNGenerated")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CollectionNoteGenerated.aspx?Pjtid={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ProjectNo")) %>></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CNConfirmed">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnkDetails" runat="server" Text='<%# Bind("CNConfirmed")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CollectionNoteConfirmed.aspx?Pjtid={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ProjectNo")) %>></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VehiclePlanned">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnkDetails" runat="server" Text='<%# Bind("VehiclePlanned")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('VehiclePlanned.aspx?Pjtid={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ProjectNo")) %>></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VehiclePlaced">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnkDetails" runat="server" Text='<%# Bind("VehiclePlaced")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('VehiclePlaced.aspx?Pjtid={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("ProjectNo")) %>></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BillSubmissionValue" HeaderText="BillSubmissionValue" Visible="false" />
            <asp:BoundField DataField="BillPaymentValue" HeaderText="BillPaymentValue" Visible="false"/>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>--%>
     <asp:Panel runat="server" id ="Panel1">
          <div class ="mapinnerdiv" >
             <br />
             <Center>
    <asp:GridView ID="GridViewPostOperation" runat="server" Height="20px" Width="657px" AutoGenerateColumns ="false"
                        CellPadding="4" ForeColor="#333333" OnRowDataBound="GridViewPostOperation_RowDataBound">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"/>
                    <Columns >
                        <asp:TemplateField HeaderText ="Criteria" ItemStyle-Width ="159px">
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="CN Generated by Thermax">
                            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_Cngenerated" runat="server"    style="color:blue;text-decoration:underline"    Text='<%#Eval("CNGenerated")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CollectionNoteGenerated.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>
                
                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="CN Confirmed by Transporter">
                             <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_CnConfirmed" runat="server" style="color:blue;text-decoration:underline"    Text='<%#Eval("CNConfirmed")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CollectionNoteConfirmed.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;
                
 <asp:Label ID="lbl_CnConfirmPercent" runat ="server" ></asp:Label>
                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="CN NotConfirmed by Transporter">
                             <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_CnConfirm" runat="server" style="color:blue;text-decoration:underline"   Text='<%#Eval("CNNotConfirmed")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CNNotConfirmed.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="lbl_Cnnotconfirm" runat ="server" ></asp:Label>
                </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText =" Need Approval from Thermax">
                             <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_NeedApproval" runat="server"  style="color:blue;text-decoration:underline"    Text='<%#Eval("NeedApproval")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CNNeedApproval.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_CnNeedApproval" runat ="server" ></asp:Label>
                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Cancelled by Thermax">
                             <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_CnConfirmed1" runat="server"  style="color:blue;text-decoration:underline"    Text='<%#Eval("Cancelled")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CNCancelled.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_CnCancelled" runat ="server" ></asp:Label>
                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Amendment by Transporter">
                             <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_CnConfirmed2" runat="server"   style="color:blue;text-decoration:underline"  Text='<%#Eval("Amendment")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('CNAmendment.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="lbl_CnAmendment" runat ="server" ></asp:Label>
                </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                 </Center> 
         <br></br>
    
    <center >
<asp:GridView ID="grd_dashboard2" runat="server" Height="20px" Width="657px" AutoGenerateColumns ="false"
                        CellPadding="4" ForeColor="#333333" OnRowDataBound="grd_dashboard2_RowDataBound">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"/>
                        <Columns >
                            <asp:TemplateField HeaderText ="Criteria" ItemStyle-Width ="159px">

                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Vehicles Planned by Thermax">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_Vehicleplanned" runat="server"  style="color:blue;text-decoration:underline"     Text='<%#Eval("VehiclePlanned")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('VehiclePlanned.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vehicles Placed by Transporter">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_Vehicleplaced" runat="server"    style="color:blue;text-decoration:underline"   Text='<%#Eval("VehiclePlaced")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('VehiclePlaced.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_VehPlaced" runat ="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                            <asp:TemplateField HeaderText ="Vehicle Loaded by Transporter">
                                <EditItemTemplate>
                <asp:TextBox ID="TextBox9" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_VehicleLoadontime" runat="server"   style="color:blue;text-decoration:underline"     Text='<%#Eval("LoadonTime")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('Loadontime.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_VehLoadontime" runat ="server" ></asp:Label>
                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText ="Vehicle Not Loaded by Transporter">
                                <EditItemTemplate>
                <asp:TextBox ID="TextBox10" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_VehicleDelayed" runat="server"   style="color:blue;text-decoration:underline"    Text='<%#Eval("DelayorFailure")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('Delayed.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="lbl_VehDelayed" runat ="server" ></asp:Label>
                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
        </center> 
         <br></br>
              <center >
<asp:GridView ID="grd_dashboard3" runat="server" Height="20px" Width="657px" AutoGenerateColumns ="false"
                        CellPadding="4" ForeColor="#333333" OnRowDataBound="grd_dashboard3_RowDataBound" Visible ="false" >
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"/>
                    <Columns >
                        <asp:TemplateField HeaderText ="Criteria" ItemStyle-Width ="159px">

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Submitted by Transporter">
                <EditItemTemplate>
                <asp:TextBox ID="TextBox11" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_BillSubmitted" runat="server" Text='<%#Eval("BillSubmitted")%>'  NavigateUrl=<%# String.Format("javascript:void(window.open('BillsubmitbyTransporter.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>
                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Validated by AARMS">
<EditItemTemplate>
                <asp:TextBox ID="TextBox12" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_BillValidated" runat="server" Text='<%#Eval("BillValiated")%>'  NavigateUrl=<%# String.Format("javascript:void(window.open('BillvalidatedbyAarms.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>
                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Discrepancy">
<EditItemTemplate>
                <asp:TextBox ID="TextBox13" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:HyperLink ID="lnk_BillDiscrepancy" runat="server"  Text='<%#Eval("Discrepancey")%>' NavigateUrl=<%# String.Format("javascript:void(window.open('BillDiscrepancy.aspx',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))") %>></asp:HyperLink>
                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Debit Note Raised by Thermax">

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Bill Paid by Thermax">

                        </asp:TemplateField>
                    </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>

<asp:GridView ID="grd_dashboard4" runat="server" Height="20px" Width="657px" AutoGenerateColumns ="false"
                        CellPadding="4" ForeColor="#333333" OnRowDataBound="grd_dashboard4_RowDataBound"  >
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"/>
                    <Columns >
                        <asp:TemplateField HeaderText ="Criteria" >

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Placement">

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Ontime Delivery">

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Shortages/Damages">

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Safe Delivery">

                        </asp:TemplateField>
                    </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <br />
             </div> 
    </asp:Panel>
    
    
    
 <%--   
    <asp:GridView ID="GridView1" runat="server" ShowFooter="true" onrowdatabound="GridView_RowDataBound">
        <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="Red" BorderColor="White" ForeColor="White" />
    </asp:GridView>--%>
     <asp:GridView ID="GridView" runat="server" ShowFooter="false" AutoGenerateColumns ="true"  onrowdatabound="GridView_RowDataBound">
    <%--<Columns >
    <asp:BoundField HeaderText ="Destination" DataField ="Route" />
    <asp:TemplateField HeaderText="ProjectNo" Visible="False">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Route") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Eval("Route") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
    <asp:BoundField HeaderText ="TripCompleted" DataField ="VehiclePlaced" />
  
     <asp:BoundField HeaderText ="Delieverd(InTons)" DataField ="TotalTons" />
    <asp:BoundField HeaderText ="AgreementPrice" DataField ="AgreementPrice" />
   
    <asp:BoundField HeaderText ="Cost(PerTon)" DataField ="PerTonCost" />
      <asp:BoundField HeaderText ="BasePrice" DataField ="BasePrice" />
    <asp:BoundField HeaderText ="Savings" DataField ="Savings" />
    <asp:TemplateField HeaderText="Details">
    <EditItemTemplate>
    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    </EditItemTemplate>
    <ItemTemplate>
    <asp:HyperLink ID="lnkDetails" runat="server"  NavigateUrl=<%# String.Format("javascript:void(window.open('DashboardVehiclePlaced.aspx?route={0}',null,'right=10px, top=134px, width=750px, height=444px, status=no,resizable= No, scrollbars=yes, toolbar=no, location=no, menubar=no'))",Eval("Route")) %>>Details</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>--%>

        <RowStyle BorderColor="Red" />
        <HeaderStyle BackColor="Red" BorderColor="White" ForeColor="White" />
    </asp:GridView>
    
    
    
    <br />
      </td>
     </tr>
        </table>        
 <table>
                 <tr>
                        <td>
              <%--  <a href="MyTripplan.aspx">
                    <asp:Label ID="Lbladposted" runat="server" Text="No of ADs Posted" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label> </a>--%>
                        </td>
                        <td>
                <%-- <a href="RoutePrice.aspx">  <asp:Label ID="lblQuotesReceived" runat="server" Text="No of Quotes Received" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label> </a>--%></td>
                             <td>
                        <%--<asp:Label ID="lblLowestQuote" runat="server" Text="Lowest Quote" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>--%> </td>
                             <td>
              <%-- <a href="#">  <asp:Label ID="lblsaving" runat="server" Text="Estimated Savings" Visible="false" Font-Bold="true" ForeColor="Red"></asp:Label> </a> --%></td>
                    </tr>
               
     
        <tr>
            <td >
                <asp:GridView ID="GridDashboard" runat="server" CellPadding="4" onrowdatabound="GridDashboard_RowDataBound" 
                    ForeColor="#333333" Visible="false">
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                </td>
        </tr>
        
      
              
    </table>
                                    </div>
           </div>
</asp:Content>

