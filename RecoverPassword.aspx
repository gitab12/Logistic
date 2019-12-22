<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
    <div style="margin-left:300px">
    <table align="center">
        <tr>
            <td>
               <b style="color:red;font-family:'Roboto',sans-serif;font-size:16px;">Enter your Email ID to recover your password:</b> 
            </td>
            <td>
                <asp:TextBox ID="txt_Email" runat="server" Width ="150px" ValidationGroup="Check"   class="form-control" ></asp:TextBox>
            </td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txt_Email" ErrorMessage="Enter Email ID" 
                        style="color: #F71919;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Check">Enter Email ID</asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Check" 
                        ControlToValidate="txt_Email" ErrorMessage="Enter valid Email ID" 
                        style="color: #F71919;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        Width="222px"></asp:RegularExpressionValidator>  
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button ID="btnpwd" runat="server" Text="Get Password" OnClick="btnpwd_Click" ValidationGroup="Check"  class="btn btn-primary"/>
            </td>
              <td>
                <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
        </div>
    <br /><br /><br /><br /><br /><br /><br />
</asp:Content>

