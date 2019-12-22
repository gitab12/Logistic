<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="LoadingStatus.aspx.cs" Inherits="LoadingStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
    <style type ="text/css">
       
    </style>

     <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="js/ScrollableGridPlugin.js" type="text/javascript"></script>
<title>Scrollable Gridview with Fixed Header</title>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#<%=Gridwindow.ClientID %>').Scrollable();
    }
)
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /> <br /><br /> <br /><br />
<style type="text/css">
   
</style>
    <div style="margin-left:15px">
<center><h2 class="title-one">Loading Status Report</h2></center>
<ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />
 <table align="center">
        <tr>
            <td>
                From: 
            </td>
            <td>
                 <asp:TextBox ID="txttravelDate" runat="server" ></asp:TextBox>
                <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txttravelDate">
 </ajaxToolkit:CalendarExtender>
            </td>
            <td>
                To:
            </td>
            <td>
                 <asp:TextBox ID="txtToDate" runat="server" ></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtToDate">
 </ajaxToolkit:CalendarExtender>
            </td>
            <td>
                &nbsp; ProjectNo :&nbsp;
                <asp:DropDownList ID="ddl_ProjectNo" runat="server" Width="104px"></asp:DropDownList>
            </td>
            <td>  &nbsp; 
                   <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" Class="btn btn-primary"/>
            </td>
        </tr>
    </table>
        </div>
    <br />
     <asp:Panel ID="panel1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:50px">
  <asp:GridView ID="Gridwindow" runat="server" AutoGenerateColumns="False" 
              ForeColor="#333333" GridLines ="Both" OnRowDataBound="Gridwindow_RowDataBound"
             EnableModelValidation="True" BorderStyle="None" >
       
              <RowStyle BorderColor="Red" />
              <Columns>
                 
                  <asp:TemplateField HeaderText="Confirmation No" Visible="true" HeaderStyle-HorizontalAlign ="Left"  >
                      <ItemTemplate>
                          <asp:Label ID="lblplanID"  runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:Label>
                         <asp:Label ID="lblplid"  runat="server" Text='<%# Bind("plid") %>' ForeColor="White"></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtplanid" runat="server" Text='<%# Bind("AcceptanceID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
               <%--    <asp:TemplateField HeaderText="Project No">
                      <ItemTemplate>
                          <asp:Label ID="lbl_ProjectNo" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtProjectno" runat="server" Text='<%# Bind("ProjectNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="WBSNo">
                      <ItemTemplate>
                          <asp:Label ID="lblWBSNo"  runat="server" Text='<%# Bind("WBSNo") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtWBSNo" runat="server" Text='<%# Bind("WBSNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="From Location">
                      <ItemTemplate>
                          <asp:Label ID="lblFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtFromLoc" runat="server" Text='<%# Bind("FromLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="To Location">
                      <ItemTemplate>
                          <asp:Label ID="lbltoloc" runat="server"  Text='<%# Bind("ToLocation") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txttoloc" runat="server" Text='<%# Bind("ToLocation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                 
                  
                  
                  
                    <asp:TemplateField HeaderText="Vehicle Requirement Date">
                      <ItemTemplate>
                          <asp:Label ID="lbldate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtdate" runat="server" Text='<%# Bind("TravelDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                    <asp:TemplateField HeaderText="Vehicle Loaded Date">
                      <ItemTemplate>
                          <asp:Label ID="lblloadeddate" runat="server"  Text='<%# Bind("LoadingDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtloadeddate" runat="server" Text=""></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Vehicle Released Date">
                      <ItemTemplate>
                          <asp:Label ID="lblReleased" runat="server"  Text='<%# Bind("ReleaseDate") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtReleased" runat="server" Text=""></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
           
                   <asp:TemplateField HeaderText="LR No.">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("LRNumber") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                         <asp:Label ID="lblLRno" runat="server" Text='<%# Bind("LRNumber") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
                  
                  
                      <asp:TemplateField HeaderText="Expected Delivery Date">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                           <asp:Label ID="lblDeliverydate" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:Label>
                            
                                 
                      </ItemTemplate>
                  </asp:TemplateField>
                 
                  
                          <asp:TemplateField HeaderText="ClientID" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
                  
                       <asp:TemplateField HeaderText="ClientAdrID" Visible="false">
                      <ItemTemplate>
                          <asp:Label ID="lblclientadrID" runat="server" Text='<%# Bind("ClientAddressLocationID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtclientadrID" runat="server" Text='<%# Bind("ClientAddressLocationID") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  
              
            <%--      <asp:TemplateField HeaderText="ClientEmail" >
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                        <asp:Label ID="lblCEmail" runat="server" Text='<%# Bind("CorporateEmail") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="VehicleNo">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VehicleNo") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblVehicleno"  runat="server" Text='<%# Bind("VehicleNo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>--%>
                  
                  <asp:BoundField DataField ="ProjectNo" HeaderText ="Project No" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="WBSNo" HeaderText ="WBSNo" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="FromLocation" HeaderText ="From Location" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="ToLocation" HeaderText ="To Location" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="TravelDate" HeaderText ="Vehicle Requirement Date" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="LoadingDate" HeaderText ="Vehicle Loaded Date" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="ReleaseDate" HeaderText ="Vehicle Released Date" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="LRNumber" HeaderText ="LR No." HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="DeliveryDate" HeaderText ="Expected Delivery Date" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="VehicleNo" HeaderText ="VehicleNo" HeaderStyle-HorizontalAlign ="Left" />

                  
                    <asp:TemplateField HeaderText="Vehicle Image of Loading Point" HeaderStyle-HorizontalAlign ="Left" >
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                       <%-- <a href="BillPreview.aspx" onClick="return popup(this, 'notes')">  <asp:Image ID="Image1" runat="server" Height="43px" Width="119px"   ImageUrl='<%# Eval("BillSubmissionNo", "BillImage.ashx?ImageID={0}")%>'/></a>--%>
                         <%-- <asp:ImageButton ID="Image1" runat="server" Height="43px" Width="100px" 
                              ImageUrl='<%# Eval("AcceptanceID", "ImageHandler.ashx?ImageID={0}")%>' 
                              onclick="Image1_Click"/><br />--%>
                           <asp:Label ID="lblImagestatus" runat="server" Text='<%# Bind("ImageStatus") %>' ForeColor="Red"></asp:Label><br />
                         <asp:LinkButton ID="link_preview" runat="server" Width="100px"  onclick="link_preview_Click" Style="color:blue;text-decoration:underline">Four view of truck</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  
              <%--<asp:TemplateField HeaderText="Status">
                      <ItemTemplate>
                          <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtstatus" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
               
                     <asp:TemplateField HeaderText="TotalWeight">
                      <ItemTemplate>
                          <asp:Label ID="lblTotalWeight" runat="server" Text='<%# Bind("TotalWeight") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTotalWeight" runat="server" Text='<%# Bind("TotalWeight") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Loading%">
                      <ItemTemplate>
                          <asp:Label ID="lblLoading" runat="server" Text='<%# Bind("Loading") %>' ForeColor="Red"></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtLoading" runat="server" Text='<%# Bind("Loading") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>--%>

                  <asp:BoundField DataField ="Status" HeaderText ="Status" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="TotalWeight" HeaderText ="TotalWeight" HeaderStyle-HorizontalAlign ="Left" />
                  <asp:BoundField DataField ="Loading" HeaderText ="Loading%" HeaderStyle-HorizontalAlign ="Left" />
                 
                  <asp:TemplateField HeaderText="Track Vehicle" HeaderStyle-HorizontalAlign ="Left" >
                      <ItemTemplate>
                      <%--<asp:HyperLink ID="LinkTrack" runat="server" NavigateUrl='<%# String.Format("http://localhost:51220/NewSCMBizconnect/TrackVehicleStatus.aspx?Field2={0}, <%# Bind('Loading') %>") %>' >Click here to track</asp:HyperLink>--%>
                          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/TrackVehicleStatus.aspx?VehicleNo={0}", HttpUtility.UrlEncode(Eval("VehicleNo").ToString())) %>' >Click here to track</asp:HyperLink>
                       <%-- <a href="" target="_blank" Style="color:blue;text-decoration:underline">Track</a>--%>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtLoading" runat="server" Text=''></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
              </Columns>
              <HeaderStyle BackColor="#B70808" BorderColor="White" ForeColor="White" />
          </asp:GridView>

</asp:Panel>
</asp:Content>
