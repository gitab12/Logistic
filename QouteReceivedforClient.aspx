<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QouteReceivedforClient.aspx.cs" Inherits="QouteReceivedforClient" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    	<link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/>
   <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
          <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
        
<asp:Label ID="lblCount" runat="server" Text="No.of Quotes:" Font-Bold="True" 
        ForeColor="Red"></asp:Label>
    
         &nbsp;&nbsp;&nbsp;&nbsp;Quotes Received From&nbsp;
        <asp:TextBox ID="txt_Fromdate" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID ="cal_ReqDate" TargetControlID ="txt_Fromdate" Format ="MM/dd/yyyy" PopupButtonID ="img_Fromdt" runat ="server" ></ajaxToolkit:CalendarExtender><asp:ImageButton ID="img_Fromdt" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" 
                />
        &nbsp;&nbsp;&nbsp;&nbsp; Quotes Received To&nbsp;
        <asp:TextBox ID="txt_Todate" runat="server"></asp:TextBox>
         <ajaxToolkit:CalendarExtender ID ="CalendarExtender1" TargetControlID ="txt_Todate" Format ="MM/dd/yyyy" PopupButtonID ="img_Todt" runat ="server" ></ajaxToolkit:CalendarExtender><asp:ImageButton ID="img_Todt" 
            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" 
                />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" Class="btn btn-primary"/>
        <br />

        <asp:Button ID="ButDownload" runat="server" Text="Download"  onclick="ButDownload_Click" Class="btn btn-primary"/>
          
          <asp:GridView ID="grd_Clientquotereceived" runat="server" DataKeyNames ="replyid"
             CellPadding="4" ForeColor="#333333" Width="90%"
             EnableModelValidation="True" BorderStyle="None" 
        AutoGenerateColumns="False" 
        onrowediting="grd_Clientquotereceived_RowEditing" 
        onrowcancelingedit="grd_Clientquotereceived_RowCancelingEdit" 
        onrowupdating="grd_Clientquotereceived_RowUpdating" OnRowDataBound ="OnRowDataBound">
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
              
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <AlternatingRowStyle BackColor="White" />
              <Columns>
              <asp:BoundField HeaderText ="QuoteID" DataField ="QuoteID" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="TCode" DataField ="TCode" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="Transporter" DataField ="Transporter" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="FromLocation" DataField ="FromLocation" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="ToLocation" DataField ="ToLocation" ReadOnly ="true"/>
                  <asp:TemplateField HeaderText="TravelDate">
                      <EditItemTemplate>
                          <asp:Label ID="Labeldate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
              <asp:BoundField HeaderText ="Trucktype" DataField ="Trucktype" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="Enclosuretype" DataField ="Enclosuretype" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="NoOfTrucks" DataField ="NoOfTrucks" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="Capactiy" DataField ="Capactiy" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="ClientPrice" DataField ="ClientPrice"  ReadOnly ="true" />
               <asp:BoundField HeaderText ="CostPerTruck" DataField ="CostPerTruck"  ReadOnly ="true" />
              <asp:BoundField HeaderText ="QuotePrice" DataField ="QuotePrice" ControlStyle-BackColor ="Khaki" >
<ControlStyle BackColor="Khaki"></ControlStyle>
                  </asp:BoundField>
              <asp:BoundField HeaderText ="Savings" DataField ="Savings" ReadOnly ="true"/>
              <asp:BoundField HeaderText ="QuoteDate" DataField ="QuoteDate" ReadOnly ="true"/>
               <asp:BoundField HeaderText ="Type" DataField ="Type" Visible ="true" />
                  <asp:TemplateField HeaderText="Status">
                      <EditItemTemplate>
                          <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
              <asp:CommandField ShowEditButton ="true" ShowCancelButton ="true" />
              </Columns>
          </asp:GridView>
    </form>
</body>
</html>
