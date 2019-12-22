<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="PBudget.aspx.cs" Inherits="PBudget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
 
 <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
     <link href="bokking_date_time_picker/src/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
   <%-- <link href="bokking_date_time_picker/css/Newjquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <link href="bokking_date_time_picker/CalenderRed/jquery-ui.css" rel="stylesheet" />
    <link href="bootstrapparsaly/Parsley/css/parsley.css" rel="stylesheet" />
    
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container master-container" style="padding-top: 66px; margin-left: 100px;">
 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
  <div class="row" runat="server" id="div_not_permission">
      <asp:Label ID="lbl_permission" runat="server" Text=""></asp:Label>
  </div>   
<div class="panel panel-primary" id="div_acess_permission" runat="server">
<div class="panel-heading"><b>Project Budget</b></div>
<div class="panel-body"> 
   
    <div class="form-horizontal">
        <div class="box-body">        
         <div class="row">
            <div class="col-md-6">
               <div class="form-group">
                  <label for="inputEmail3" class="col-sm-3 control-label">Project Name</label>

                  <div class="col-sm-7 input-group"> 
                    <span class="input-group-addon"><i class="fa fa-edit"></i></span>                  
                    <asp:DropDownList ID="ddl_project_name" class="form-control" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddl_project_name_SelectedIndexChanged"></asp:DropDownList>
                  </div>
                </div>
               <div class="form-group">
                  <label for="inputEmail3" class="col-sm-3 control-label">Project No.</label>

                  <div class="col-sm-7 input-group">
                    <span class="input-group-addon"><i class="fa fa-edit"></i></span>
                    <asp:DropDownList ID="ddl_projectno" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_projectno_SelectedIndexChanged"></asp:DropDownList>
                  </div>
                </div>
               <div class="form-group">
                  <label for="inputEmail3" class="col-sm-3 control-label">Collection Note No.</label>

                  <div class="col-sm-7 input-group">
                    <span class="input-group-addon"><i class="fa fa-sort-numeric-asc"></i></span>
                    <asp:DropDownList ID="ddl_collectionnoteno" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_collectionnoteno_SelectedIndexChanged"></asp:DropDownList>
                  </div>
                </div>
               <div class="form-group">
                  <label for="inputEmail3" class="col-sm-3 control-label">Project Assign</label>

                  <div class="col-sm-7 input-group">
                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                    <asp:TextBox ID="txt_projectasign_date" data-parsley-required="true" data-parsley-required-message="" data-parsley-error-message=""  autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                  </div>
                </div>
             </div>
            <div class="col-md-6">
               <div class="form-group">
                  <label for="inputEmail3" class="col-sm-3 control-label">Assign Amt.

                  </label>

                  <div class="col-sm-7 input-group">
                    <span class="input-group-addon"><i class="fa fa-inr"></i></span>
                    <asp:TextBox ID="txt_assignamt"  class="form-control" disabled="disabled" runat="server" >0</asp:TextBox>
                  </div>
                </div>
               <div class="form-group">
                  <label for="inputEmail3" class="col-sm-3 control-label">Budget Amt.</label>

                  <div class="col-sm-7 input-group">
                    <span class="input-group-addon"><i class="fa fa-inr"></i></span>
                    <asp:TextBox ID="txt_budgetamt" data-parsley-type="number" data-parsley-trigger="change" data-parsley-required="true" data-parsley-required-message="" data-parsley-error-message="" autocomplete="off"  class="form-control" runat="server"></asp:TextBox>                    
                  </div>
                </div>
               <div class="form-group">
                  <label for="inputEmail3" class="col-sm-3 control-label">Total Amt.</label>
                  <div class="col-sm-7 input-group">
                    <span class="input-group-addon"><i class="fa fa-inr"></i></span>
                   <asp:TextBox ID="txt_totalamt" class="form-control" disabled="disabled" runat="server"></asp:TextBox>
                  </div>
                </div>
                <asp:HiddenField ID="hfclientid" runat="server" />
               <div class="form-group" style="display:none;">
                  <label for="inputEmail3" class="col-sm-2 control-label">Email</label>

                  <div class="col-sm-8 input-group">
                    <span class="input-group-addon">@</span>
                    <input type="email" class="form-control" id="Email7" placeholder="Email">
                  </div>
                </div>
             </div>
         </div>        
        </div>
        <!-- /.box-body -->
        <hr />
        <div class="box-footer">
        <button type="button" id="btn_check" class="btn btn-default">Cancel</button>
        <asp:Button ID="Button1" runat="server" class="btn btn-info pull-right" Text="Submit" />
        </div>
        <!-- /.box-footer -->
    </div>
    </div>
</div>
</div>
   
    <script>
        var totalamtt = 0;
        var assignmnt = 0;
        var budgetamt = 0;
        $('#<%= txt_budgetamt.ClientID %>').keyup(function () {

            try
            {
                assignmnt = $('#<%= txt_assignamt.ClientID %>').val();
                budgetamt = $('#<%= txt_budgetamt.ClientID %>').val();
                totalamtt = assignmnt - budgetamt;
                $('#<%= txt_totalamt.ClientID %>').val(totalamtt);
            }
            catch(ex)
            {
                $('#<%= txt_totalamt.ClientID %>').val(totalamtt);
            }
        });
    </script>



     <script src="bokking_date_time_picker/js/jquery-ui.min.js"></script>
     <script src="bokking_date_time_picker/js/jquery-ui.js" type="text/javascript"></script>
    <script src="bokking_date_time_picker/src/jquery-ui-timepicker-addon.js" type="text/javascript"></script>	
        <script src="bokking_date_time_picker/dist/i18n/jquery-ui-timepicker-addon-i18n.min.js" type="text/javascript"></script>			
        <script src="bokking_date_time_picker/dist/jquery-ui-sliderAccess.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(document).ready(function () {

             $('#<%= txt_projectasign_date.ClientID %>').datetimepicker({
                 controlType: 'select',
                 oneLine: true,
                 timeFormat: 'hh:mm tt',
                 //minDate: 0,
                 maxDate: 0
             });
            
         });
  </script>  
  
  <script src="bootstrapparsaly/Parsley/js/parsley.min.js"></script>
  <script>
      $('#aspnetForm').parsley();
</script>
</asp:Content>


