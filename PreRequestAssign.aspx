<%@ Page Language="C#" MasterPageFile="~/MasterPage/AarmsMasterPage.master" AutoEventWireup="true" CodeFile="PreRequestAssign.aspx.cs" Inherits="PreRequestAssgn" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><<br />
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

    &nbsp;<br />

<div style="margin-left:350px">  
      <table width="70%">
        <tr>
            <td style="width: 100px; height: 205px;">
    <asp:GridView ID="GridAssign" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="Vertical" Width="70%" Font-Names="Arial" Font-Size="10pt" onrowdatabound="GridAssign_RowDataBound" >
        <RowStyle BackColor="#C2DDEB" ForeColor="#333333" BorderStyle="None" Width="70%" />
        <Columns>
            <asp:TemplateField HeaderText="AD ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("adid") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbladid" runat="server" Text='<%# Bind("adid") %>' Width="120px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Client">
           <HeaderTemplate >
            <asp:Label ID="lblclient" Text="Client Name" runat="server" Width="80px" />
                <br />
                <asp:DropDownList ID="DDLclient" runat="server" Width="80px"  Style="color:#000">
               
                    <asp:ListItem  Style="color:#000">All</asp:ListItem>
                    <asp:ListItem  Style="color:#000">Saint Gobain</asp:ListItem>
                    <asp:ListItem  Style="color:#000">LG Electronics</asp:ListItem>
                </asp:DropDownList>
           </HeaderTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("client") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("client") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trucks Req.">
             <HeaderTemplate >
            <asp:Label ID="lbltrucksreq" Text="Trucks Req." runat="server" Width="80px"/>
                <br />
                <asp:DropDownList ID="DDLreq" runat="server" Width="80px"  Style="color:#000">
               
                    <asp:ListItem  Style="color:#000">All</asp:ListItem>
                    <asp:ListItem  Style="color:#000">50</asp:ListItem>
                    <asp:ListItem  Style="color:#000">30</asp:ListItem>
                </asp:DropDownList>
           </HeaderTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("trucks") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("trucks") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Budget Cost">
             <HeaderTemplate >
            <asp:Label ID="lblbudget" Text="Budget Cost" runat="server" Width="80px"/>
                <br />
                <asp:DropDownList ID="DDLBudget" runat="server" Width="80px"  Style="color:#000">
               
                    <asp:ListItem  Style="color:#000">All</asp:ListItem>
                    <asp:ListItem  Style="color:#000">35000</asp:ListItem>
                    <asp:ListItem  Style="color:#000">40000</asp:ListItem>
                </asp:DropDownList>
           </HeaderTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Bcost") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Bcost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("assign") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <a href="#"  onclick="mouseXY(event);" >   <asp:Label ID="Lblassign" runat="server" Text='<%# Bind("assign") %>'></asp:Label></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trucks Assigned">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("assigned") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("assigned") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cost/Truck">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("cost") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("cost") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                   <asp:Label ID="Lblstatus" runat="server"
                         ForeColor="Red" Text="waiting for approval" Font-Size="10px"></asp:Label>
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
    </div>

<div style="margin-left:350px">  
 <div id="openwindow"  style="display:none; border:solid 3px red; width:416px;"   >
     
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
         <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="415px" >
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
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("assign") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="Txtassign" runat="server" Width="37px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="White" />
      </asp:GridView>            
     <asp:Button ID="ButAssign" runat="server" Text="Send for Approval" />
     <asp:Button ID="Butclose" runat="server" Text="Close"  /></div>
   </div>  
    <br /><br /><br /><br /><br />
   </asp:Content>