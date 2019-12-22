<%@ Page Language="VB" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="false" CodeFile="Myassignment.aspx.vb" Inherits="Myassignment" Title ="My Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <br /><br /><br />
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

document.getElementById("openwindow").style.display ="block";
document.getElementById("openwindow").style.left=(5+mouseX-(screen.width-myWidth))+ "px";
document.getElementById("openwindow").style.top=(10+mouseY+(screen.height-myHeight))+ "px";
document.getElementById("openwindow").style.position="absolute";
	
	}

</script>


         <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="415px"  Style="margin-left:150px">
          <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="Select">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("select") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      &nbsp;<asp:CheckBox ID="Checkassign" runat="server" Text="." />
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="quoteid" HeaderText="QuoteID" />
              <asp:BoundField DataField="trucks" HeaderText="No of Trucks" />
              <asp:BoundField DataField="cost" HeaderText="Cost" />
              <asp:TemplateField HeaderText="Assigned">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="Txtassign" runat="server" Width="37px" Text='<%# Bind("assign") %>'></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Approved">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("approved") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("approved") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="status" HeaderText="status" />
          </Columns>
          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="White" />
      </asp:GridView>            
     

&nbsp;<br />
    <div style="margin-left:150px" >
            <table width="70%">
        <tr>
            <td style="width: 100px; height: 205px;">
    <asp:GridView ID="GridAssign" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="Vertical" Width="69%" Font-Names="Arial" Font-Size="10pt" onrowdatabound="GridAssign_RowDataBound" >
        <RowStyle BackColor="#C2DDEB" ForeColor="#333333" BorderStyle="None" Width="70%" />
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="Check" runat="server" Text="." />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AD ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("adid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbladid" runat="server" Text='<%# Bind("adid") %>' Width="90px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("client") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("client") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type/Capacity" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("trucktype") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("trucktype") %>' Width="80px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trucks Req.">
            
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("trucks") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("trucks") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Budget Cost">
             
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Bcost") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Bcost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoteid">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("quoteid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("quoteid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Transporter">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("transname") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("transname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quoted Cost/Truck">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("cost") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblcost" runat="server" Text='<%# Bind("cost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trucks Assigned">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("assigned") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAssignedTrucks" runat="server" Text='<%# Bind("assigned") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Saving">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("saving") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("saving") %>'></asp:Label>
                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    
                     <a href="#"  onclick="mouseXY(event);" >   <asp:Label ID="Lblstatus" runat="server" Text='<%# Bind("status") %>'></asp:Label></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="From" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("From") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("From") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("To") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("To") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rid" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblrid" runat="server" Text='<%# Bind("recid") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("recid") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Postid" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblpostid" runat="server" Text='<%# Bind("Postid") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Postid") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
                <asp:Button ID="Butassignment" runat="server" Text="Send for Acceptance" class="btn btn-primary"/></td>
        </tr>
    </table>

        </div>

 <div id="openwindow"  style="display:none; border:solid 3px red; width:416px;margin-left:150px">
     
     <table width="100%" style="background-color: #ffffcc">
         <tr>
             <td >
                 Adid&nbsp; :AARMS-MUM-VWD-1234</td>
             <td>
                 Tripid :1001</td>
         </tr>
         <tr>
             <td>
                 Source :Mumbai</td>
             <td >
                 Destination :Vijayawada</td>
         </tr>
         <tr>
             <td>
                 Trucks req :30</td>
             <td>
                 Date :26 Dec 2010</td>
         </tr>
     </table>
     
     <asp:Button ID="Butclose" runat="server" Text="Close"   Class="btn btn-primary"/></div>
</asp:Content>

