<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="MultipleConfirmation.aspx.cs" Inherits="MultipleConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
           <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-left:80px;">
    <center><h2 class="title-one">Multiple Vehicle Confirmation</h2></center> 
        </div>        
    <br />
      <%--<asp:LinkButton ID ="lnk_TripIndent" runat ="server" ></asp:LinkButton>--%>
     <div class="row text-center clearfix">
        <div class="col-sm-11 col-sm-offset-3">
        
   
     <asp:Panel ID ="pnl_Indent" runat ="server">
          <div class="row">                
        <div class="col-sm-5 form-group">
    <a href ="http://www.scmbizconnect.com/Excel/MultipleVehicleConfirmation.xlsx" style="color:blue;text-decoration:underline">Download the Template For Multiple Confirmation</a><br />
     </div>
            </div>   
            <br/>
              <div class="row">   
              <div class="col-sm-3 form-group">
          <asp:FileUpload ID="ExcelUpload" runat="server" />
                  </div>
              <div class="col-sm-1 form-group">
    <asp:Button ID="btn_UploadAndDisplay" runat="server" 
       Text="Validate"  onclick="btn_UploadAndDisplay_Click1"  class="btn btn-primary" />
                  </div>
               <div class="col-sm-3 form-group">
    <asp:Button ID="btn_Upload" runat="server" Text="Confirm" onclick="btn_Upload_Click" 
        Enabled="False"  class="btn btn-primary" />
                   </div>
               </div>
         <br /><br />
        <asp:GridView ID="grd_DisplayUploadfile" runat="server" Width="70%" 
        ForeColor="#333333" GridLines="both" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
         </asp:Panel> 
       </div>
        </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

