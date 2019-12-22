<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ImportExportMaster.master" AutoEventWireup="true" CodeFile="VendorMaster.aspx.cs" Inherits="ImportExport_VendorMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type ="text/css" >    

        .design {
             background: #ADD8E6;
             padding: 25px;
             border: 2px solid #fff;
             box-shadow: 0px -4px 5px rgba(0,0,0,0.3);
             color: #000;          
             padding-bottom: 15px;
             min-width: 400px;
             min-height: 200px;
             max-height: 550px;
             max-width: 900px;
           
        }
      

        .txtboxcss
        {
            border-bottom-right-radius: 8em;
            border-top-right-radius: 20px;
            border-bottom-left-radius: 20px;
            border-bottom-right-radius: 20px;
            border: 1px solid gray;
            padding: 1px;
            background-color: #ffffff;
        }
        

         .Panel legend
{
color:Maroon;
 font-weight:bold; 
 font-size :15px;
}

         .promotion_btn {
        -moz-box-shadow: inset 0px 1px 0px 0px #efdcfb;
        -webkit-box-shadow: inset 0px 1px 0px 0px #efdcfb;
        box-shadow: inset 0px 1px 0px 0px #efdcfb;
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #FFFFF), color-stop(1, #BCC6CC));
        background: -moz-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: -webkit-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: -o-linear-gradient(top,#FFFFF 5%, #BCC6CC 100%);
        background: -ms-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: linear-gradient(to bottom, #FFFFF 5%, #BCC6CC 100%);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFF', endColorstr='#BCC6CC',GradientType=0);
        background-color: #fff;
        -moz-border-radius: 10px;
        -webkit-border-radius: 10px;
        border-radius: 10px;
        border: 1px solid #c584f3;
        display: inline-block;
        cursor: pointer;
        color: black;
        font-family: arial;
        font-size: 15px;
        font-weight: bold;
        padding: 7px 25px;
        text-decoration: none;
        text-shadow: 0px 1px 0px #9752cc;
    }
    .promotion_btn:hover {
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #BCC6CC), color-stop(1, #FFFFF));
        background: -moz-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -webkit-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -o-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -ms-linear-gradient(top,#FFFFF 5%, #FFFFF 100%);
        background: linear-gradient(to bottom, #FFFFF 5%, #FFFFF 100%);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFF', endColorstr='#FFFFF',GradientType=0);
        background-color: #BCC6CC;
    }
    .promotion_btn:active {
        position: relative;
        top: 1px;
    }

        .auto-style5 {
            width: 100px;
        }

    </style>

    <script type="text/javascript">
        //Only Numbers
        function onlynumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 48 || charCode > 57) && (charCode != 8))
                return false;
            return true;
        }
        //only alphabetical with space
        function onlyalphawithspace(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 8) && (charCode != 32))

                return false;
            return true;
        }
         </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <asp:Panel ID ="pnl_Ordermanagement" GroupingText ="Vendor Master" CssClass="Panel" Width ="400px" runat ="server" >
        <table align="left" cellpadding ="5" cellspacing ="2">
            <tr>
                <td class="auto-style5">
                   Vendor name
                </td>
                <td>
                    <asp:TextBox ID="txt_Vendorname" width="200px" onkeypress="return onlyalphawithspace(event)" cssclass="txtboxcss" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfv_Vendorname" runat="server" 
                       ControlToValidate="txt_Vendorname" ErrorMessage="*" ></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td class="auto-style5">
                   Contact person
                </td>
                <td>
                    <asp:TextBox ID="txt_Contactperson" width="200px" onkeypress="return onlyalphawithspace(event)" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_ContactPerson" runat="server" 
                       ControlToValidate="txt_Contactperson" ErrorMessage="*" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                   Contact no
                </td>
                <td>
                    <asp:TextBox ID="txt_Contactno" width="200px" cssclass="txtboxcss" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfv_ContactNo" runat="server" 
                       ControlToValidate="txt_Contactno" ErrorMessage="*" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                  Email id
                </td>
                <td>
                    <asp:TextBox ID="txt_Emailid" width="200px" cssclass="txtboxcss" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Email" runat="server" 
                       ControlToValidate="txt_Emailid" ErrorMessage="*" ></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="REV_Emailid" runat="server" 
                       ControlToValidate="txt_Emailid" ErrorMessage="Invalid email-ID"  
                       ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                       Width="111px"></asp:RegularExpressionValidator>

                </td>
            </tr>

              <tr>
                <td class="auto-style5">
                   Address
                </td>
                <td>
                    <asp:TextBox ID="txt_Address" TextMode ="MultiLine" Height ="100px" width="200px" cssclass="txtboxcss" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr align ="center">
               <td colspan ="2">
                    <br />
                   <asp:Button ID="btn_Submit" runat="server" class="promotion_btn" Text="Submit" OnClick="btn_Submit_Click" />
                </td>
            </tr>

            </table> 
        </asp:Panel> 
</asp:Content>

