<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testemailsending.aspx.cs" Inherits="Testemailsending" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
 <form id="form1" class="form-horizontal" runat="server">
   <div class="row">
     <div class="col-sm-10">
        <div class="panel panel-primary">
    <div class="panel-heading">
        <h3 class="panel-title">Send SMS</h3>
    </div>
    <div class="panel-body">
        <div class="form-group">
                <label class="control-label col-sm-2" for="pwd">CNNumber:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCNNumber" runat="server" class="form-control">123456</asp:TextBox>
                   
                </div>
            </div>
         <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">                    
                    <asp:Button ID="btn_sendmail" runat="server" class="btn btn-primary active" Text="Sending Mail" OnClick="btn_sendmail_Click" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-10">
                    <div id="div_msg">
                       <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
    </div>
 </div>
     </div>
   </div>       
</form>
</body>
</html>
