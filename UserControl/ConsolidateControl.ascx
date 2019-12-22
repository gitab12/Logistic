<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsolidateControl.ascx.cs" Inherits="UserControl_ConsolidateControl" %>

<link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="css/prettyPhoto.css" rel="stylesheet"/> 
    <link href="css/font-awesome.min.css" rel="stylesheet" />
	<link href="css/animate.css" rel="stylesheet"/> 
	<link href="css/main.css" rel="stylesheet"/>
	<link href="css/responsive.css" rel="stylesheet"/>
<script language="javascript" type="text/javascript">


//display of tabs
function setVisibility(id, visibility) {

    document.getElementById(id).style.display = visibility;

}
function mouseXY(event)
//refer http://www.codelifter.com/main/javascript/capturemouseposition1.html
 {
var mouseX =Math.round (event.clientX);
var mouseY = Math.round (event.clientY);
var myWidth = window.innerWidth;
var myHeight = window.innerHeight;
var top = 10 + mouseY + (screen.height - myHeight);
//alert(top);
document.getElementById('<%=HiddenField1.ClientID%>').value = "test";
 document.getElementById('<%=HiddenField1.ClientID%>').value;

document.getElementById("openwindow").style.display ="block";
document.getElementById("openwindow").style.left=(5+mouseX-(screen.width-myWidth))+ "px";
//document.getElementById("openwindow").style.top = document.documentElement.scrollHeight - (myHeight - mouseY - 10) + "px";
document.getElementById("openwindow").style.top = (10 + mouseY - (screen.height - myHeight)) + "px";
document.getElementById("openwindow").style.position="absolute";

//alert(document.documentElement.scrollHeight + "mouseY = " + mouseY + " screen.height = " + screen.height + " myHeight=" + myHeight + "  top=" + document.getElementById("openwindow").style.top);
	}

</script>
<div style="margin-left:200px">
<asp:Button ID="Butpostad" runat="server" Text="Post Ad in Junction" Width="204px" onclick="Butpostad_Click"   Class="btn btn-primary"/>
    &nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Button ID="btn_postrfq" runat="server" OnClick="btn_postrfq_Click" ValidationGroup ="abc" Text="Post RFQ"  Class="btn btn-primary"/>
    &nbsp;&nbsp;&nbsp;
<asp:Button ID="sendmail" runat="server" Text="send mail"   onclick="sendmail_Click"  Class="btn btn-primary" />
<asp:HiddenField ID="HiddenField1" runat="server" />  

Show only by
<asp:DropDownList ID="DDLShow" runat="server" AutoPostBack="True">
    <asp:ListItem>Trip Date</asp:ListItem>
    <asp:ListItem>Client Name</asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>All</asp:ListItem>
</asp:DropDownList>

 &nbsp;
<asp:DropDownList ID="ddl_period" runat="server" Width="91px">
    <asp:ListItem>--Select--</asp:ListItem>
    <asp:ListItem>Monthly</asp:ListItem>
    <asp:ListItem>Quarterly</asp:ListItem>
    <asp:ListItem>Half-yearly</asp:ListItem>
    <asp:ListItem>Yearly</asp:ListItem>
</asp:DropDownList>
 
 <asp:RequiredFieldValidator ID="rfv_period" runat="server"  ControlToValidate="ddl_period" Display ="None"  ValidationGroup ="abc" InitialValue ="--Select--" ErrorMessage="Select period"></asp:RequiredFieldValidator>
<asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox ="true" ShowSummary ="false"  ValidationGroup ="abc" runat="server" />
 
 
  <br />
         <asp:Label ID="lblmsg" runat="server" Font-Bold="True" 
    Font-Names="Arial" Font-Size="12pt" ForeColor="Red" 
    Text="ADs Posted In Junction" Visible="False"></asp:Label>
         <br />  
</div>
    

<asp:GridView ID="Gridclientplan" runat="server" AutoGenerateColumns="False" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" GridLines="Vertical" onrowdatabound="Gridclientplan_RowDataBound"  Width="70%">
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
       <asp:TemplateField  HeaderText="CheckALL" >
            
            <HeaderTemplate>
             
             
                   <asp:Label ID="lblcheck" Text="All" runat="server" /><br />
                        <asp:CheckBox ID="CheckAll" runat="server"  AutoPostBack="True" 
                       oncheckedchanged="CheckAll_CheckedChanged" />
            </HeaderTemplate>
           
            <ItemTemplate>
                <asp:CheckBox ID="Checkitem" runat="server" Text="." Width="6px" />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Source">
        
            <HeaderTemplate>
              <asp:Label ID="lblsource" Text="Source" runat="server" Width="80px" />
                <br />
                <asp:DropDownList ID="DDLsource" runat="server" Width="80px">
               
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblsource" runat="server" Text='<%# Bind("source") %>'></asp:Label>
             
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Designation">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("designation") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lbldesg" Text="Destination" runat="server" />
                <br />
                <asp:DropDownList ID="DDLdesignation" runat="server" Width="80px">
               
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lbldesignation" runat="server" Text='<%# Bind("designation") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type/Capacity">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("truckcapacity") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lblTrucktype" Text="Type/Capacity" runat="server" />
                <br />
                <asp:DropDownList ID="DDLtrucktype" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lbltruckcapacity" runat="server" Text='<%# Bind("truckcapacity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Type">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("traveltype") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
             <asp:Label ID="lbltraveltype" Text="Travel Type" runat="server" />
                <br />
                <asp:DropDownList ID="DDLtraveltype" runat="server" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lbltraveltype" runat="server" Text='<%# Bind("traveltype") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Required">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("truckreq") %>'></asp:TextBox>
                <div id="div1" style="position:relative"></div>
            </EditItemTemplate>
            <ItemTemplate>
 <%--    <a href="#"  onmouseover="mouseXY(event);" onmouseout="setVisibility('openwindow','none');">--%> 
    <a href='Consolidateplan.aspx?source=<%# Eval("source") %>&designation=<%# Eval("designation") %>&Traveltype=<%# Eval("ttid") %>&Tdate=<%# Eval("tdate") %> &Truckcapacity=<%# Eval("truckcapacity") %>&Trucktype=<%# Eval("tktid") %>'>
 <asp:Label ID="lbltruckreq" runat="server" Text='<%# Bind("truckreq") %>  ' onclick="return mouseXY(event);"  >Click to view details</asp:Label></a>
<%--</a>--%>
     <%--  <asp:LinkButton ID="View" runat="server" onclick="View_Click">Click to view details</asp:LinkButton>    --%>
  

            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="TDate" Visible="False">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tdate") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Lbltdate" runat="server" Text='<%# Bind("tdate") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Traveltypeid" Visible="False">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ttid") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblttid" runat="server" Text='<%# Bind("ttid") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Trucktypeid" Visible="False">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("tktid") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbltktid" runat="server" Text='<%# Bind("tktid") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="capacity" Visible="False">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("capacity") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblcapacity" runat="server" Text='<%# Bind("capacity") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Comments">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblRemaks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="EnclType">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Encl") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblEncl" runat="server" Text='<%# Bind("Encl") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("product") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblproduct" runat="server" Text='<%# Bind("product") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        


  
</asp:GridView>
   
<asp:Button ID="Butpostad1" runat="server" Text="Post Ad in Junction" 
    Width="204px" onclick="Butpostad1_Click"   Class="btn btn-primary" />


<div id="openwindow"   >
  <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False"  
    CellPadding="4" ForeColor="#333333" Visible="False" >
          <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          <Columns>
              <asp:BoundField DataField="client" HeaderText="Client" />
              <asp:BoundField DataField="trucksreq" HeaderText="Trucks Req." />
              <asp:BoundField DataField="budget" HeaderText="Budget Cost" />
              <asp:BoundField DataField="posted" HeaderText="Posted on" />
          </Columns>
          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="White" />
      </asp:GridView>
      
       <asp:Label ID="lbldisp" runat="server" Visible="false"></asp:Label>

</div>
   
 

