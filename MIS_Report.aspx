<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MIS_Report.aspx.cs" Inherits="MIS_Report" %>

<asp:Content ID="Content_Head" ContentPlaceHolderID="head" Runat="Server">
    <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
</asp:Content>
<asp:Content ID="Content_Body" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <div class="container master-container" style=" padding-top: 66px;margin-left: 100px; ">
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
  <div class="row" runat="server" id="div_not_permission">
      <asp:Label ID="lbl_permission" runat="server" Text=""></asp:Label>
  </div>   
    <div class="panel panel-info" id="div_acess_permission" runat="server">
         <div class="panel-heading" align="center"><h4 class="title-one">MIS Report</h4></div><br />
        <div  class="form-group" align="center"><h4>Search By Project No. & WBS No:</h4></div>
    <div class="panel-body">
         <div class="col-lg-12"> 
             <div class="panel-body">
        <div class="form-horizontal" role="form">
            <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">Project No.</label>
                <div class="col-lg-9">
                    <asp:DropDownList ID="ddl_ProjectNo" runat="server"  class="form-control" OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged" AutoPostBack ="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="ddl_ProjectNo" ValidationGroup="NewValidationGroup1" ErrorMessage="Please select Project No!"></asp:RequiredFieldValidator>


                </div>
                    </div>
            </div>
             <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">WBS No.</label>
                <div class="col-lg-9">
                    <asp:DropDownList ID="ddl_Wbsno" runat="server"  class="form-control" >
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="ddl_Wbsno" ValidationGroup="NewValidationGroup1" ErrorMessage="Please select WBS No!"></asp:RequiredFieldValidator>


                </div>
                    </div>
            </div>
                 </div>
                  <div class="col-md-6">
                <div class="form-group">
                  <asp:Button ID="btn_Search" runat="server" Text="Search"  ValidationGroup="NewValidationGroup1" class="btn btn-success center-block" OnClick="btn_Search_Click" />
               </div>
           </div>
                  <div class="col-md-6">
                <div class="form-group">
                  <asp:Button ID="btn_DownloadFullMIS" runat="server" Text="Direct Download to Excel"  ValidationGroup="NewValidationGroup1" class="btn btn-success center-block" OnClick="btn_DownloadFullMIS_Click" />
               </div>
           </div>
            
			
                <div  class="form-group" align="center"><h4><u>YearWise Report :</u></h4></div><br />
            <div class="form-horizontal" role="form">
            <div class="col-md-6" >
                <div class="form-group">
                <label for="inputcmp" class="col-sm-3 control-label">Select Year:</label>
                <div class="col-lg-9">
                    <asp:DropDownList ID="ddl_year" runat="server"  class="form-control"  AutoPostBack ="true">
                        
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">2019</asp:ListItem>
                        <asp:ListItem Value="2">2018</asp:ListItem>
                        <asp:ListItem Value="3">2017</asp:ListItem>
                        <asp:ListItem Value="4">2016</asp:ListItem>
                        <asp:ListItem Value="5">2015</asp:ListItem>
                        <asp:ListItem Value="6">2014</asp:ListItem>
                    </asp:DropDownList>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="ddl_year" ValidationGroup="NewValidationGroup3" ErrorMessage="Please select Year!"></asp:RequiredFieldValidator>--%>


                </div>
                    </div>
            </div>
                <div class="col-md-6">
                <div class="col-lg-3">
                  <asp:Button ID="btn_downloadsearch" runat="server" Text="Search"  ValidationGroup="NewValidationGroup3" class="btn btn-success center-block" OnClick="btn_downloadsearch_Click"  />
               </div>
                    <div class="col-lg-3">
                  <asp:Button ID="btn_download" runat="server" Text="Download YearWise Report"  ValidationGroup="NewValidationGroup3" class="btn btn-success center-block" OnClick="btn_download_Click"  />
               </div>
           </div>
                </div>
                 <br /> <br />
                  

            <h4 style="text-align:center;">Advanced Search :</h4>
                 <div class="col-md-12">
                 <div class="form-horizontal col-md-4" role="form">
        <div  class="form-group" ><h4><u>Collection Note Status </u></h4></div>   
                 
                 <asp:CheckBoxList ID="chkCNstatus" runat="server">
                        <asp:ListItem Value="1">Confirmed</asp:ListItem>
                        <asp:ListItem Value="0">Not Confirmed</asp:ListItem>
                        <asp:ListItem Value="2">Amendment</asp:ListItem>
                        <asp:ListItem Value="4">Need Approval</asp:ListItem>
                        <asp:ListItem Value="3">Cancelled</asp:ListItem>
                    </asp:CheckBoxList>

                     </div>
                     <asp:HiddenField ID="hfclientid" runat="server" />
                  <div class="form-horizontal col-md-4" role="form">
        <div  class="form-group" ><h4><u>Trip Status</u> </h4></div>   
                 
                 <asp:CheckBoxList ID="chkTripconfirm" runat="server">
                        <asp:ListItem Value="1"> &nbsp;&nbsp;Trip Confirm</asp:ListItem>
                        <asp:ListItem Value="0"> &nbsp;&nbsp;Trip Not Confirm</asp:ListItem>
                    </asp:CheckBoxList>
                     </div>

                  <div class="form-horizontal col-md-4" role="form">
        <div  class="form-group" ><h4><u>Loading Status</u></h4></div>   
                 
                <asp:CheckBoxList ID="chkloadedstatus" runat="server">
                        <asp:ListItem Value="1"> &nbsp;&nbsp;Loaded</asp:ListItem>
                        <asp:ListItem Value="0"> &nbsp;&nbsp;Not Loaded</asp:ListItem>
                    </asp:CheckBoxList>
                     </div>
                     </div>
                 <div class="col-md-6">
                <div class="form-group">
                  <asp:Button ID="btnsearch" runat="server" Text="AdvancedSearch"  ValidationGroup="NewValidationGroup" class="btn btn-success center-block" OnClick="btnsearch_Click" />
               </div>
           </div>
                  <div class="col-md-6">
                <div class="form-group">
                  <asp:Button ID="Button2" runat="server" Text="Download To Excel"  ValidationGroup="NewValidationGroup" class="btn btn-success center-block" OnClick="Button2_Click" />
               </div>
           </div>
                   </div>

                 </div>
         </div>
        </div>
    </div>

    <asp:Panel ID="pnl_MisReport" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="1220px" ScrollBars="Auto"  Style="margin-left:116px" Visible="false">
        <asp:GridView ID="grd_MsiReport" runat="server"></asp:GridView>
         </asp:Panel>
       
</asp:Content>
