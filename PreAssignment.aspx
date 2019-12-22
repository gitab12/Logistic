<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PreAssignment.aspx.cs" Inherits="PreAssignment" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>    <meta name="keywords" content="BizConnect, Supply Chain Management, Road Transports, Indian Road Transportation, Supply Demand Matching, Trucks Available, Trucks Wanted, Goods Transport, Logistics"  />
	<meta name="description" content="SCM Junction is an initiative from AARM SCM Solutions Pvt. Ltd., Bengaluru, India; to build a logistics open platform to match supply and demand of road transportation in India." />
	<meta name="author" content="AARM SCM Solutions Pvt. Ltd." />
	<meta name="robots" content="ALL"/>
	<meta name="revisit-after" content="1 days"/>
	<meta name="classification" content="Website, Corporate"/>
	<meta name="distribution" content="Global"/>
	<meta name="rating" content="General"/>
	<meta name="copyright" content="Copyright (C) 2010, AARM SCM Solutions Pvt. Ltd." />
	<meta name="language" content="English"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br /><br /><br />


   <div style="margin-left:300px">

    <script language="javascript" type="text/javascript" src="Scripts/dhtmlgoodies_calendar.js">
</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<link type="text/css" rel="stylesheet" href="Scripts/dhtmlgoodies_calendar.css?random=20051112" media="screen"></link>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <table width="100%">
        <tr>
            <td style="width: 200px; height: 205px;">
    <asp:GridView ID="GridAssign" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="Vertical" Width="100%" Font-Names="Arial" Font-Size="10pt">
        <RowStyle BackColor="#C2DDEB" ForeColor="#333333" BorderStyle="None" Width="100%" />
        <Columns>

        <%--Ad ID--%>
            <asp:TemplateField HeaderText="AD ID">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("adid") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:TextBox ID="txtAdID" runat="server" BorderWidth="0px" BackColor="Transparent"
                    Font-Bold="True" Font-Size="7pt" ForeColor="#D50045" Width="125px" 
                    
                    Text='<%# Eval("AdID") %>'></asp:TextBox>
                   
                </ItemTemplate>
            </asp:TemplateField>

        <%--Travel Date--%>
            <asp:TemplateField HeaderText="Travel Date">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("adid") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lblTravelDate" Font-Size="8" runat="server" Text='<%# Eval("TravelDate") %>'  Width="60px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        <%--Client Name--%>
            <asp:TemplateField HeaderText="Client">
           <HeaderTemplate >
            <asp:Label ID="lblclient" Text="Client Name" runat="server" Width="80px"/>
                <br />
                <asp:DropDownList ID="DDLclient" runat="server" Width="80px" style="color:#000;">
               
                    <asp:ListItem style="color:#000;">All</asp:ListItem>
                    <asp:ListItem style="color:#000;">Saint Gobain</asp:ListItem>
                    <asp:ListItem style="color:#000;">LG Electronics</asp:ListItem>
                </asp:DropDownList>
           </HeaderTemplate>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("client") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        <%--Trucks Required--%>
            <asp:TemplateField HeaderText="Trucks Req.">
             <HeaderTemplate >
            <asp:Label ID="lbltrucksreq" Text="Trucks Req." runat="server" Width="80px"/>
                <br />
                <asp:DropDownList ID="DDLreq" runat="server" Width="80px" style="color:#000;">
               
                    <asp:ListItem style="color:#000;">All</asp:ListItem>
                    <asp:ListItem style="color:#000;">50</asp:ListItem>
                    <asp:ListItem style="color:#000;">30</asp:ListItem>
                </asp:DropDownList>
           </HeaderTemplate>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("trucks") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lblTrucksRequired" runat="server" Text='<%# Eval("TruckRequired") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        <%--Budgeted Cost--%>
            <asp:TemplateField HeaderText="Budget Cost">
             <HeaderTemplate >
            <asp:Label ID="lblbudget" Text="Budget Cost" runat="server" Width="80px"/>
                <br />
                <asp:DropDownList ID="DDLBudget" runat="server" Width="80px" style="color:#000;">
               
                    <asp:ListItem style="color:#000;">All</asp:ListItem>
                    <asp:ListItem style="color:#000;">35000</asp:ListItem>
                    <asp:ListItem style="color:#000;">40000</asp:ListItem>
                </asp:DropDownList>
           </HeaderTemplate>
                
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Bcost") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                <asp:Image ID="ImgBudgetedCost" runat="server" Height="11px" ImageAlign="Bottom" 
                           ImageUrl="~/Images/INR.png" Width="8px" />
                    <asp:Label ID="lblBudgetedCost" runat="server" Text='<%# Eval("BudgetedCost") %>' 
                    ForeColor="Maroon" Font-Bold="true" Font-Size="11" Width="35"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        <%--Assign--%>
            <asp:TemplateField HeaderText="Quote Received">
                <ItemTemplate>
                   <a href="#"
                    onmouseup  =''
                    onclick="javascript: GetAdID('<%# ((GridViewRow)Container).FindControl("txtAdID").ClientID %>','<%# ((GridViewRow)Container).FindControl("txtLogisticsPlanNo").ClientID %>');window.open('TruckAssignment.aspx','test','left=250px, top=245px, width=450px, height=400px, scrollbars=yes, toolbar=no, menubar=no, status=no, resizable=no');" >
                    <asp:Label ID="Lblassign" runat="server" Text='<%# Bind("QuoteCount") %>'></asp:Label></a>
                </ItemTemplate>
            </asp:TemplateField>

        <%--Truck Assigned--%>
            <asp:TemplateField HeaderText="Quoted Trucks">
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("assigned") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lblQuotedTrucks" runat="server" Text='<%# Eval("QuotedTrucks") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             
        <%--Quoted Cost--%>
            <asp:TemplateField HeaderText="Quoted Cost/Truck">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("cost") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                <asp:Image ID="ImgQuotedCost" runat="server" Height="11px" ImageAlign="Bottom" 
                           ImageUrl="~/Images/INR.png" Width="8px" />
                    <asp:Label ID="lblQuotedCost" runat="server" Text='<%# Eval("QuotedCost") %>'
                               Font-Bold="true" Font-Size="10" Width="30"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        <%--Saving--%>
            <asp:TemplateField HeaderText="Saving Cost">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("saving") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                <asp:Image ID="ImgSavingCost" runat="server" Height="11px" ImageAlign="Bottom" 
                           ImageUrl="~/Images/INR.png" Width="60px" />
                    <asp:Label ID="lblSaving" runat="server" Text='<%# Eval("Saving") %>'
                               Font-Bold="True" Font-Size="10pt" Width="60px" ForeColor="#009933"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        <%--Status--%>
            <asp:TemplateField HeaderText="Status">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                   <asp:Label ID="Lblstatus" runat="server" Width="60"
                         ForeColor="Red" Text="Waiting for Assignment" Font-Bold="true" Font-Size="10px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <%--LogisticsPlanNo--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="txtLogisticsPlanNo" runat="server" BorderWidth="0px" BackColor="Transparent"
                    Font-Bold="True" Font-Size="7pt" ForeColor="#C2DDEB" Width="10px"
                    Text='<%# Eval("LogisticsPlanNo") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
            </td>
        </tr>
    </table>
            <asp:HiddenField ID="hdf_AdID" runat="server" />
             <asp:HiddenField ID="hdf_LogisticsPlanNo" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
       
   </div>
     <br /><br /><br />
</asp:Content>

