<%@ Page Language="C#"  MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

     <script type ="text/javascript" >
         //only alphabetical with space
         function onlyalphawithspace(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode != 8) && (charCode != 32))

                 return false;
             return true;
         }


         //Only Numbers
         function onlynumber(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 48 || charCode > 57) && (charCode != 8))
                 return false;
             return true;
         }
    </script>

    <style type="text/css">

        
        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :550px;
    height :1400px;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        background:rgba(217, 211, 182, 0.30);
        /*background:rgba(248, 127, 10, 0.60);*/
    }
    .mapinnerdiv {
    margin:5px;
    padding:0;
     width :540px;
    height :1390px;
    border:1px solid rgba(0,0,0,0.5);
    border-radius:20px 20px 20px 20px;
    -webkit-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    -moz-box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
    box-shadow:
        0 2px 6px rgba(0,0,0,0.5),
        inset 0 1px rgba(255,255,255,0.3),
        inset 0 10px rgba(255,255,255,0.2),
        inset 0 10px 20px rgba(255,255,255,0.25),
        inset 0 -15px 30px rgba(0,0,0,0.3);
        /*background:rgba(0,0,0,0.25);*/
        /*background:rgba(26, 154, 228, 0.87);*/
        background:rgb(255, 255, 255);
    }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
        --%><div style="margin-left:370px">
         <asp:Label ID="Label2" runat="server"  Visible="false" Text="0"></asp:Label>
            <asp:Label ID="Label3" runat="server"  Visible="false"></asp:Label>
             <asp:Label ID="Label4" runat="server"  Visible="false" Text="null"></asp:Label>
            
            <table border="0" cellpadding="0"  cellspacing="0">
                <tr>
                    
                    <br />
                    <th colspan="3" > &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add New User
                        <br />
                    <br />   
                    </th>
                </tr>
                <tr>
                    <td>First Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtFname"  Width="173px" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtFnamerfv" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtFname"
                            runat="server" />
                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>
                
                <tr>
                    <td>Last Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtLname" Width="173px" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtLnamervf" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtLname"
                            runat="server" />
                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>
                <tr>
                    <td>Gender
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGender" Width="173" runat="server">
                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>

                <tr>
                    <td>Department 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartment" Width="173" runat="server">
                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                            <asp:ListItem Value="1">Logistic</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>

                <tr>
                    <td>Designation 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDesignation" DataTextField="Designation"
                            DataValueField="DesignationID" Width="173" runat="server">
                        </asp:DropDownList>

                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>

                <tr>
                    <td>Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" Width="173px" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtEmailrfv" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                            ControlToValidate="txtEmail" runat="server" />
                        <asp:RegularExpressionValidator ID="txtEmailrev" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>


                <tr>
                    <td>Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" Width="173px" runat="server" TextMode="Password" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtPasswordrfv" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                            runat="server" />
                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>
                <tr>
                    <td>Confirm Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword"  Width="173px" runat="server" TextMode="Password" />
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" runat="server" />
                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>
                <tr>
                    <td>Mobile No.
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile"  Width="173px" runat="server" MaxLength="10" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="txtMobilerfv" ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtMobile"
                            runat="server" />

                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>

                <tr>
                    <td>Phone No.
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone"  Width="173px" runat="server" />
                    </td>
                    <td style="padding-bottom:28px;"> </td>
                </tr>


                <tr>
                    <td></td>
                    <td><br />
                        <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="RegisterUser" />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>
         <br /><br />
        </div>

  <%--  </form>
</body>
</html>
     --%>
    </asp:Content>

