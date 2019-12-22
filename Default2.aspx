<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <div  id="dvGrid">
              
              <asp:Panel ID="Panel23" runat="server" ScrollBars="Auto">
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <div>
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                         <asp:Label ID="lbl_msg_advice" runat="server" Text=""></asp:Label>
             
                    </div>
                 </ContentTemplate>
               </asp:UpdatePanel>               
             </asp:Panel> 
                          
           
           </div>

<script src="js/jquery.blockUI.js"></script>
<script type="text/javascript">
    $(function () {
        BlockUI("dvGrid");
        $.blockUI.defaults.css = {};
    });
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({
                message: '<div align = "center">' + '<img src="images/loadingAnim.gif"/></div>',
                css: {},
                overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
            });
        });
        prm.add_endRequest(function () {
            $("#" + elementID).unblock();
        });
    };
</script>
    </form>
</body>
</html>

