<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/LoginMasterPage.master" AutoEventWireup="true" CodeFile="LoginAdmin.aspx.cs" Inherits="LoginAdmin" %>

<asp:Content ID="Content_Head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content_Body" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <!-- /.login-logo -->
  <div class="login-box-body">
    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
    <p class="login-box-msg">Sign in to start your session</p>     
    <div>
      <div class="form-group has-feedback">
        <asp:TextBox ID="txt_username" runat="server"  data-validation="required" data-validation-error-msg=" "  class="form-control" autofocus="1" placeholder="Email Or Username"></asp:TextBox>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">  
        <asp:TextBox ID="txt_password" TextMode="Password" runat="server" class="form-control"  data-validation="required" data-validation-error-msg=" "  placeholder="Password"></asp:TextBox>              
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <div class="checkbox icheck">
            <label>
              <input type="checkbox" /> Remember Me
            </label>
          </div>
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
          <asp:Button ID="btn_login" runat="server" Text="Sign In" 
                class="btn btn-primary btn-block btn-flat" onclick="btn_login_Click"  />           
        </div>
        <!-- /.col -->
      </div>
    </div>

    <div class="social-auth-links text-center">
      <p>- OR -</p>
      <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign in using
        Facebook</a>
      <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Sign in using
        Google+</a>
    </div>
    <!-- /.social-auth-links -->

    <a href="#">I forgot my password</a><br>
    <a href="~/Registration.aspx" id="login" runat="server" class="text-center">Register a new membership</a>

  </div>
  <!-- /.login-box-body -->
</asp:Content>

