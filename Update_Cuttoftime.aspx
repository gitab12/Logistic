<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Update_Cuttoftime.aspx.cs" Inherits="Update_Cuttoftime" %>

<asp:Content ID="Content_Head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content_Body" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Dashboard
        <small>Control panel</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Update Cuttofftime</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
     <div class="box box-primary">
      <div class="box-header with-border">
          <h3 class="box-title">Update Cuttofftime</h3>

          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
          </div>
        </div>
      <!-- Small boxes (Stat box) -->
     <div class="form-horizontal">
      <div class="box-body">
       <div class="row">
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div ><%--class="small-box bg-aqua"--%>
            <div class="form-group">
              <label for="inputEmail3" class="col-sm-2 control-label"> Date</label>
               <div class="col-sm-10">                
                <asp:DropDownList ID="ddl_date" class="form-control select2" runat="server">
                 <asp:ListItem Value="1">1</asp:ListItem>
                 <asp:ListItem Value="2">2</asp:ListItem>
                 <asp:ListItem Value="3">3</asp:ListItem>
                 <asp:ListItem Value="4">4</asp:ListItem>
                 <asp:ListItem Value="5">5</asp:ListItem>
                 <asp:ListItem Value="6">6</asp:ListItem>
                 <asp:ListItem Value="7">7</asp:ListItem>
                 <asp:ListItem Value="8">8</asp:ListItem>
                 <asp:ListItem Value="9">9</asp:ListItem>
                 <asp:ListItem Value="10">10</asp:ListItem>
                 <asp:ListItem Value="11">11</asp:ListItem>
                 <asp:ListItem Value="12">12</asp:ListItem>
                 <asp:ListItem Value="13">13</asp:ListItem>
                 <asp:ListItem Value="14">14</asp:ListItem>
                 <asp:ListItem Value="15">15</asp:ListItem>
                 <asp:ListItem Value="16">16</asp:ListItem>
                 <asp:ListItem Value="17">17</asp:ListItem>
                 <asp:ListItem Value="18">18</asp:ListItem>
                 <asp:ListItem Value="19">19</asp:ListItem>
                 <asp:ListItem Value="20">20</asp:ListItem>
                 <asp:ListItem Value="21">21</asp:ListItem>
                 <asp:ListItem Value="22">22</asp:ListItem>
                 <asp:ListItem Value="23">23</asp:ListItem>
                 <asp:ListItem Value="24">24</asp:ListItem>
                 <asp:ListItem Value="25">25</asp:ListItem>
                 <asp:ListItem Value="26">26</asp:ListItem>
                 <asp:ListItem Value="27">27</asp:ListItem>
                 <asp:ListItem Value="28">28</asp:ListItem>
                 <asp:ListItem Value="29">29</asp:ListItem>
                 <asp:ListItem Value="30">30</asp:ListItem>
                 <asp:ListItem Value="31">31</asp:ListItem>
               </asp:DropDownList>
              </div>
            </div>           
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div> <%--class="small-box bg-aqua"--%>
            <div class="form-group">
              <label for="inputEmail3" class="col-sm-2 control-label"> Month</label>
               <div class="col-sm-10">                
                <asp:DropDownList ID="ddl_month" class="form-control select2" runat="server">
                 <asp:ListItem Value="1">1</asp:ListItem>
                 <asp:ListItem Value="2">2</asp:ListItem>
                 <asp:ListItem Value="3">3</asp:ListItem>
                 <asp:ListItem Value="4">4</asp:ListItem>
                 <asp:ListItem Value="5">5</asp:ListItem>
                 <asp:ListItem Value="6">6</asp:ListItem>
                 <asp:ListItem Value="7">7</asp:ListItem>
                 <asp:ListItem Value="8">8</asp:ListItem>
                 <asp:ListItem Value="9">9</asp:ListItem>
                 <asp:ListItem Value="10">10</asp:ListItem>
                 <asp:ListItem Value="11">11</asp:ListItem>
                 <asp:ListItem Value="12">12</asp:ListItem>                 
               </asp:DropDownList>
              </div>
            </div>           
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div> <%--class="small-box bg-aqua"--%>
            <div class="form-group">
              <label for="inputEmail3" class="col-sm-2 control-label"> Year</label>
               <div class="col-sm-10">                
                <asp:DropDownList ID="ddl_year" class="form-control select2" runat="server">
                 <asp:ListItem Value="2018" Selected="True">2018</asp:ListItem>
                 <asp:ListItem Value="2019">2019</asp:ListItem>
                 <asp:ListItem Value="2020">2020</asp:ListItem>                 
               </asp:DropDownList>
              </div>
            </div>           
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <div class="form-group">
            <%--  <label for="inputEmail3" class="col-sm-2 control-label">     </label>--%>
               <div class="col-sm-10" style="margin-top: -13px;">                
               <asp:Button ID="btn_getcuttofdata" runat="server" Text="Get cuttoff Data" class="btn bg-navy margin" OnClick="btn_getcuttofdata_Click"></asp:Button>
              </div>
            </div>
        </div>
        <!-- ./col -->
      </div>
      <div class="row">
          <div class="col-md-12">
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
          </div>          
      </div>
       <div class="row" runat="server" id="div_grid" style="margin-left: -22px;">
            <div class="col-md-12">
             <div class="box box-primary">
              <div class="table-responsive no-padding">
               <asp:GridView ID="gv_showdata" class="table table-hover" runat="server"  AutoGenerateColumns="False"  AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" DataKeyNames="PostID" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" >
                   <Columns>
                    <asp:TemplateField HeaderText = "SN." ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>                   
                    <asp:TemplateField HeaderText="PostID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_PostID" runat="server" Text='<%# Eval("PostID") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PostByID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_PostByID" runat="server" Text='<%# Eval("PostByID") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FromLocation">
                    <ItemTemplate>
                        <asp:Label ID="lbl_FromLocation" runat="server" Text='<%# Eval("FromLocation") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ToLocation">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ToLocation" runat="server" Text='<%# Eval("ToLocation") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="RequirementDate">
                    <ItemTemplate>
                        <asp:Label ID="lbl_RequirementDate" runat="server" Text='<%# Eval("RequirementDate") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="AdditionalComments">
                    <ItemTemplate>
                        <asp:Label ID="lbl_AdditionalComments" runat="server" Text='<%# Eval("AdditionalComments") %>'></asp:Label>                                    
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAdditionalComments" runat="server" Text='<%# Eval("AdditionalComments") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="BidStartTime">
                    <ItemTemplate>
                        <asp:Label ID="lbl_BidStartTime" runat="server" Text='<%# Eval("BidStartTime") %>'></asp:Label>                                    
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBidStartTime" runat="server" Text='<%# Eval("BidStartTime") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lbl_City" runat="server" Text='<%# Eval("City") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Charging">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Charging" runat="server" Text='<%# Eval("Charging") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>--%>
                   <%-- <asp:TemplateField HeaderText="LAT">
                    <ItemTemplate>
                        <asp:Label ID="lbl_LAT" runat="server" Text='<%# Eval("LAT") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>--%>
                   <%-- <asp:TemplateField HeaderText="LONG">
                    <ItemTemplate>
                        <asp:Label ID="lbl_LONG" runat="server" Text='<%# Eval("LONG") %>'></asp:Label>                                    
                    </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn bg-navy margin"  ShowEditButton="true" 
                    ItemStyle-Width="150"/>
                    </Columns>  
          </asp:GridView>    
              </div>
            </div>
            </div>
           
        <!-- /.col -->
        
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>
      
      </div>
       <div class="row">
            
            <div class="form-group col-md-10">
                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                 <asp:Label ID="lbl_msg1" runat="server" Text=""></asp:Label>
            </div>
          </div>
      </div>
     </div>
     </div>
    </section>
   <!-- /.content -->
   
</asp:Content>

