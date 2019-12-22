<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="ProjectMaster.aspx.cs" Inherits="ProjectMaster" %>
<%--<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagName="DashboardMenuBar" TagPrefix="Uc4" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
   
    <script src="Dropdownsearcable_link/jquery.min.js"></script>
    <script src="Dropdownsearcable_link/bootstrap.min.js"></script>
    <link href="Dropdownsearcable_link/bootstrap.min.css" rel="stylesheet" />
    <script src="Dropdownsearcable_link/bootstrap-select.min.js"></script>
    <link href="Dropdownsearcable_link/bootstrap-select.min.css" rel="stylesheet" />
    <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

     <style type="text/css"> 
.mydiv {
    position:absolute;
    top: 55%;
    left: 33%;
    width:40em;
    height:43.5em;
    margin-top: -9em; /*set to a negative number 1/2 of your height*/
    margin-left: -15em; /*set to a negative number 1/2 of your width*/
    border: 1px solid #ccc;
    /*background-color: #f3f3f3;*/
}

        .auto-style1 {
            width: 222px;
        }


        
        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :450px;
    height :700px;
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
       width :440px;
    height :680px;
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
 <br />

 <div class="container">
   <div class="row">
    <br /><br /><br /><br /><br /><br />                        
     <div class="row text-center clearfix">
         <div class="col-sm-8 col-sm-offset-4">	
      <div class ="mapouterdiv mydiv " id="outer" >
         <div class ="mapinnerdiv"  id="inner" >

              

     <asp:Panel ID ="pnl_Project" runat ="server" class =""  >
    <table width="55%">
        <tr>
            <td colspan="2" style="font-family: Arial; font-size: large; color: #FF0000">
             <center >   Project Creation</center></td>
        </tr>
         <tr>
            <td>
                <asp:RadioButton ID ="rdb_AddProject" runat ="server" Text ="Add Project" Checked ="true" GroupName ="aarms" AutoPostBack ="true" OnCheckedChanged ="rdb_AddProject_CheckedChanged"  />
            </td>
             <td>
                <asp:RadioButton ID ="rdb_EditProject" runat ="server" Text ="Edit Project" GroupName ="aarms" AutoPostBack ="true"  OnCheckedChanged="rdb_EditProject_CheckedChanged"  />

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server"  Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Project No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProjNo" runat="server"  BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_txtProjNo" ValidationGroup="reg" runat="server" ErrorMessage="Enter Project No" ControlToValidate="txtProjNo" ForeColor="Red"></asp:RequiredFieldValidator>
                 <asp:DropDownList ID="ddl_Projectno" runat="server" Visible ="false" Width ="245px" AutoPostBack ="true" OnSelectedIndexChanged ="ddl_Projectno_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Project Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProjName" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="reg" runat="server" ErrorMessage="Enter Project Name" ControlToValidate="txtProjName" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Project Location"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProjLocation" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="reg" runat="server" ErrorMessage="Enter Project Location" ControlToValidate="txtProjLocation" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="CSG Rate Contract"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProjWorkOrder" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
            
        </tr>
       <tr>
             <br />
            <td>
                <asp:Label ID="lbl_Tranaporter" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Transporter"></asp:Label>
                
            </td>
            <td>
                <br />
                <asp:TextBox ID="txt_Transporter" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"  Visible="false" ></asp:TextBox>
           
             
               
                  <asp:DropDownList ID="ddl_Transporter" class="selectpicker" data-live-search-style="begins"
                        data-live-search="true" runat="server"  ></asp:DropDownList> 
                 <br /><br />
            </td>
        </tr>
        <tr>
            <td valign ="top" >
                <asp:Label ID="lbl_TransporterEmail" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Transporter EmailID"></asp:Label>
            </td>
            <td valign ="top" >
                <asp:TextBox ID="txt_TransporterEmail" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="rfv_TransporterEmail" ValidationGroup="reg" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txt_TransporterEmail">Enter EmailID</asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator ID="rgv_TransporterEmail" ValidationGroup="reg" runat="server" ErrorMessage="Enter valid EmailID" ControlToValidate="txt_TransporterEmail" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                
            </td>
        </tr>
        <tr>
            <td valign ="top" >
                <asp:Label ID="lbl_ProjectManager" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Project Manager"></asp:Label>
            </td>
            <td valign ="top" >
                <asp:TextBox ID="txt_ProjectManager" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign ="top">
                <asp:Label ID="lbl_ProjectManagerEmail" runat="server" Font-Bold="False" Font-Names="Arial" Width ="150px"
                    Font-Size="10pt" ForeColor="Red" Text="PM EmailID"></asp:Label>
            </td>
            <td valign ="top">
                <asp:TextBox ID="txt_ProjectManagerEmail" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="rfv_ProjectManagerEmail" ValidationGroup="reg" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txt_ProjectManagerEmail">Enter EmailID</asp:RequiredFieldValidator>
                &nbsp;
                <asp:RegularExpressionValidator ID="rgv_ProjectManagerEmail" ValidationGroup="reg" runat="server" ErrorMessage="Enter valid EmailID" ControlToValidate="txt_ProjectManagerEmail" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td valign ="top">
                <asp:Label ID="lbl_MobileNo" runat="server" Font-Bold="False" Font-Names="Arial" Width ="150px"
                    Font-Size="10pt" ForeColor="Red" Text="PM MobileNo"></asp:Label>
            </td>
            <td valign ="top">
                <asp:TextBox ID="txt_PMMobileNo" runat="server" BorderColor="Black" MaxLength="10"  onkeypress="return onlynumber(event)"
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="reg" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txt_PMMobileNo">Enter Valid 10 Digit Mobile No</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validmobileno" ValidationGroup="reg" runat="server" ErrorMessage="Invalid Mobile No." ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" controlToValidate="txt_PMMobileNo"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td valign ="top">
                <asp:Label ID="lbl_SiteIncharge" runat="server" Font-Bold="False" Font-Names="Arial" Width ="150px"
                    Font-Size="10pt" ForeColor="Red" Text="Site Incharge"></asp:Label>
            </td>
            <td valign ="top">
                <asp:TextBox ID="txt_Siteincharge" runat="server" BorderColor="Black"  
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td valign ="top">
                <asp:Label ID="lbl_InchargeEmailid" runat="server" Font-Bold="False" Font-Names="Arial" Width ="150px"
                    Font-Size="10pt" ForeColor="Red" Text="Site Incharge EmailID"></asp:Label>
            </td>
            <td valign ="top">
                <asp:TextBox ID="txt_InchargeEmailid" runat="server" BorderColor="Black"  
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="rfv_InchargeEmailID" ValidationGroup="reg" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txt_InchargeEmailid">Enter EmailID</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="rgv_InchargeEmailID" ValidationGroup="reg" runat="server" ErrorMessage="Enter valid EmailID" ControlToValidate="txt_InchargeEmailid" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td valign ="top">
                <asp:Label ID="lbl_Inchargemobileno" runat="server" Font-Bold="False" Font-Names="Arial" Width ="150px"
                    Font-Size="10pt" ForeColor="Red" Text="Site Incharge Mobile No"></asp:Label>
            </td>
            <td valign ="top">
                <asp:TextBox ID="txt_InchargeMobileNo" runat="server" BorderColor="Black" MaxLength="10"  onkeypress="return onlynumber(event)"
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
              <%--  <asp:RequiredFieldValidator ID="rfv_InchargeMobNo" ValidationGroup="reg" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txt_InchargeMobileNo">Enter Valid 10 Digit Mobile No</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="rgv_InchargeMobNo" ValidationGroup="reg" runat="server" ErrorMessage="Invalid Mobile No." ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" controlToValidate="txt_InchargeMobileNo"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
         <tr>
            <td valign ="top">
                <asp:Label ID="lbl_LogisticPerson" runat="server" Font-Bold="False" Font-Names="Arial" Width ="150px"
                    Font-Size="10pt" ForeColor="Red" Text="Logistic Manager"></asp:Label>
            </td>
            <td valign ="top">
                <asp:TextBox ID="txt_LogisticPerson" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign ="top">
                <asp:Label ID="lbl_LogisticPersonEmail" runat="server" Font-Bold="False" Font-Names="Arial" Width ="150px"
                    Font-Size="10pt" ForeColor="Red" Text="Logistic Manager EmailID"></asp:Label>
            </td>
            <td valign ="top">
                <asp:TextBox ID="txt_LogisticPersonEmail" runat="server" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="rfv_InchargeEmailID0" ValidationGroup="reg" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txt_LogisticPersonEmail">Enter EmailID</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="rgv_InchargeEmailID0" ValidationGroup="reg" runat="server" ErrorMessage="Enter valid EmailID" ControlToValidate="txt_LogisticPersonEmail" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td valign ="top" style ="color :red ;Font-Size:small;">
                Shipping Person</td>
            <td valign ="top">
                <asp:TextBox ID="txt_ShippingPerson" runat="server" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign ="top" style ="color :red ;Font-Size:small;">
                Shipping Person EmailID</td>
            <td valign ="top">
                <asp:TextBox ID="txt_ShippingpersonEmail" runat="server" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign ="top" style ="color :red ;Font-Size:small;">
                Approval Person</td>
            <td valign ="top">
                <asp:TextBox ID="txt_ApprovalPerson" runat="server" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign ="top" style ="color :red ;Font-Size:small;">
                Approval Person EmailID</td>
            <td valign ="top">
                <asp:TextBox ID="txt_ApprovalPersonEmail" runat="server" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Width="243px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <br />
                <asp:Button ID="Button1" ValidationGroup="reg" runat="server" onclick="Button1_Click" Text="Submit" Width="125px" class="btn btn-primary" />
            </td>
        </tr>
    </table>
         </asp:Panel> 
             </div> 
          </div>              
                                    </div>
         </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /> <br /><br /><br /><br /><br /><br /><br /><br /><br />
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /> <br /><br /><br />
     <br /><br /><br /><br /><br /><br /><br />
   </div>
 </div>                            
</asp:Content>

