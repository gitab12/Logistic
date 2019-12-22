<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrationPage.aspx.cs" Inherits="RegistrationPage"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:400px"><h2 class="title-one"> VEHICLE TRACKING REGISTRATION</h2></div>
    <br />
    <div style="margin-left:200px">
<table>
<tr>
    <td>
   <asp:RadioButton ID="RadTransportCompany" runat="server" GroupName="a" Checked="true"
            Text="Transport Company" ForeColor="Black" /></td>
    <td>
       <asp:RadioButton ID="RadTransConsultant" runat="server" GroupName="a" 
            Text="Transport Consultant" ForeColor="Black" /></td>
    <td>
        <asp:RadioButton ID="RadTransporter" runat="server" GroupName="a" 
            Text="Transporter" ForeColor="Black" />
    </td>
    <td rowspan="12">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/VehicleTrack.JPG" />
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lbltransportername" runat="server" Text="Name" 
            ForeColor="Black"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txttransportername" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Enter Name" ControlToValidate="txttransportername" 
            ValidationGroup="E"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lblvehicleowner" runat="server" Text="Vehicle Owner Name"  ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtvehicleownername" runat="server"></asp:TextBox>
</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="Enter Owner Name" ControlToValidate="txtvehicleownername" 
        ValidationGroup="E"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblvehicleno" runat="server" Text="Vehicle Number"  ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtvehicleno" runat="server"></asp:TextBox>
</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="lbldrivername" runat="server" Text="Driver Name"  ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtdrivername" runat="server"></asp:TextBox>
</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="Enter Driver Name" ControlToValidate="txtdrivername" 
        ValidationGroup="E" ></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lbldriverage" runat="server" Text="Driver Age"  ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtdriverage" runat="server"></asp:TextBox>
</td>
<td id="*">
    &nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="drivermobileno" runat="server" Text="Mobile Number"  
        ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtdrivermobno" runat="server" MaxLength="10" onkeypress="return onlynumber(event)"></asp:TextBox>
</td>
<td>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Must be 10 digit number" ValidationGroup="E" 
        ControlToValidate="txtdrivermobno" ValidationExpression="^[0-9]{10}" Type="Integer"></asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblmobilemake" runat="server" Text="Mobile Make"  ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="DDLMobileMake" runat="server" Width="132px">
        <asp:ListItem>Nokia</asp:ListItem>
        <asp:ListItem>Samsung</asp:ListItem>
        <asp:ListItem>Sony Ericsson</asp:ListItem>
        <asp:ListItem>Motorola</asp:ListItem>
        <asp:ListItem>Micromax</asp:ListItem>
        <asp:ListItem>LG</asp:ListItem>
        <asp:ListItem>Apple</asp:ListItem>
          <asp:ListItem>BlackBerry</asp:ListItem>
        <asp:ListItem>Spice</asp:ListItem>
        <asp:ListItem>Karbonn</asp:ListItem>
        <asp:ListItem>Videocon</asp:ListItem>
         <asp:ListItem>Others</asp:ListItem>
    </asp:DropDownList>
</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblservericeprovider" runat="server" 
        Text="Mobile Service Provider"  ForeColor="Black"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="DDLServiceProvider" runat="server" Width="132px">
        <asp:ListItem>Airtel</asp:ListItem>
        <asp:ListItem>BSNL</asp:ListItem>
        <asp:ListItem>Vodafone</asp:ListItem>
        <asp:ListItem>Reliance</asp:ListItem>
        <asp:ListItem>Idea</asp:ListItem>
        <asp:ListItem>Tata communications</asp:ListItem>
        <asp:ListItem>Aircel</asp:ListItem>
        <asp:ListItem>MTNL</asp:ListItem>
        </asp:DropDownList>
</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblhasgps" runat="server" Text="HAS GPS"  ForeColor="Black"></asp:Label>
</td>
<td>
       <asp:DropDownList ID="ddlgps" runat="server">
           <asp:ListItem>Yes</asp:ListItem>
           <asp:ListItem>No</asp:ListItem>
       </asp:DropDownList>
   </td>
   <td>
   </td>
</tr>
<tr>
<td>
    <asp:Label ID="lblsinglesim" runat="server" Text="Single/Double SIM"  ForeColor="Black"></asp:Label>
</td>
   <td>
       <asp:RadioButton ID="radyes" runat="server" Text="Yes" Checked="True" 
           GroupName="S" ForeColor="Black" />
   </td>
   <td>
       <asp:RadioButton ID="radno" runat="server" Text="No" GroupName="S" 
           ForeColor="Black" />
   </td>
</tr>
<tr>
<td>
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" onclick="btnsubmit_Click" ValidationGroup="E" Class="btn btn-primary"  />
</td>
<td>
    <asp:Button ID="btncancel" runat="server" Text="Cancel"  onclick="btncancel_Click" Class="btn btn-primary" />
</td>
<td>
    &nbsp;</td>
</tr>
</table>
        </div>
      <br /><br /><br /><br /><br /><br />
</asp:Content>

