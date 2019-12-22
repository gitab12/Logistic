<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AddBranch.aspx.cs" Inherits="AddBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:450px">
<div><h2 class="title-one"><i>Add Branches</i></h2></div>
<table align="center">
<tr>
<td>
<b>Transporter:</b>
</td>
<td>
    <asp:DropDownList ID="ddltrasportid" runat="server" Width="140px" >
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
<b>Branch Name:</b>
</td>
<td>
    <asp:TextBox ID="txtBrnchname" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>Address:</b>
</td>
<td>
<asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>City:</b>
</td>
<td>
<asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>PinCode:</b>
</td>
<td>
<asp:TextBox ID="txtpincode" runat="server" text="0"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>FirstName:</b>
</td>
<td>
<asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="validcompname" runat="server" ErrorMessage="Enter Name" controlToValidate="txtfname"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<b>Designation:</b>
</td>
<td>
<asp:TextBox ID="txtdesig" runat="server" text="0"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>Mobile No.:</b>
</td>
<td>
<asp:TextBox ID="txtmobno" runat="server" text="0" MaxLength="10" onkeypress="return onlynumber(event)"></asp:TextBox>
<asp:RegularExpressionValidator ID="validmobileno" runat="server" ErrorMessage="Invalid Mobile No." ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" controlToValidate="txtmobno"></asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td>
<b>Email ID:</b> 
</td>
<td>
<asp:TextBox ID="txtemailid" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="validemailid" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txtemailid">Enter EmailID</asp:RequiredFieldValidator><br/>
<asp:RegularExpressionValidator ID="validemail" runat="server" ErrorMessage="Enter valid EmailID" ControlToValidate="txtemailid" 
ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

</td>
</tr>
<tr>
<td>
</td>
<td>
    <asp:Button ID="btnsubmit" runat="server" Text="Submit"  onclick="btnsubmit_Click"  Class="btn btn-primary"/>
</td>
<td>
    <asp:Label ID="lblmsg" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="Green"></asp:Label>
</td>
</tr>
</table>     
        </div>
    <br /><br /><br /><br /><br />
</asp:Content>

