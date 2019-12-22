<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="Bill_Deletion.aspx.cs" Inherits="Bill_Deletion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
     <style type="text/css">
table.gridtable {
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:Black;
	border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;
}
table.gridtable th {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #dedede;
}
table.gridtable td {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #ffffff;
}
         </style>

    
     <script type="text/javascript">

         // only numbers
         function onlynumber(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 48 || charCode > 57) && (charCode != 8))
                 return false;
             return true;
         }
         </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div style="margin-left:50px">
    <table align="center" border="1"  rules="cols" frame="box"  >
        <tr align="center" style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
            <td colspan ="4">
              <center>  
                   <br />
                  <h2 class="title-one">Bill Edit/Delete</h2>
                  <br /> <br />
                  LR Number : <%--<asp:DropDownList ID="ddl_LrNo" Width="150px" AutoPostBack ="true" runat="server" OnSelectedIndexChanged="ddl_LrNo_SelectedIndexChanged"></asp:DropDownList>--%>
                  <asp:TextBox ID="txt_lrnumber" AutoPostBack="true" runat="server" OnTextChanged="txt_lrnumber_TextChanged"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  Confirm Number : <asp:DropDownList ID="ddl_ConfirmNo" Width="150px" AutoPostBack ="true" runat="server" OnSelectedIndexChanged="ddl_ConfirmNo_SelectedIndexChanged"></asp:DropDownList>
                  <br />
                  <br />
                </center>
            </td>
            
        </tr>

        <tr  style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
            <td>
                <br />
                Bill No&nbsp;
                <br />
                <asp:TextBox ID="txt_Billno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Billno" runat="server" validationGroup="bill" ErrorMessage="Enter BillNo" controlToValidate="txt_Billno" style="Color:red;"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
            <td>
                Bill Date&nbsp;
                <br />
                <asp:TextBox ID="txt_Billdate" runat="server"></asp:TextBox>
                 <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxtoolkit:calendarextender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
 PopupButtonID="imgdate1" TargetControlID="txt_Billdate" >
 </ajaxtoolkit:calendarextender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationGroup="bill" runat="server" ErrorMessage="Enter BillNo" controlToValidate="txt_Billdate" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Bill Value
                <br />
                <asp:TextBox ID="txt_Billvalue" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationGroup="bill" runat="server" ErrorMessage="Enter Billvalue" controlToValidate="txt_Billvalue" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Confirm No
                <br />
                <asp:TextBox ID="txt_Confirmno" enabled="false" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr  style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
            <td>
                <br />
                LR Number<br />
                <asp:TextBox ID="txt_Lrno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" validationGroup="bill" runat="server" ErrorMessage="Enter LRNo" controlToValidate="txt_Lrno" style="Color:red;"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
            <td>
                LR Date
                <br />
                <asp:TextBox ID="txt_Lrdate" runat="server"></asp:TextBox>
                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
<ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
 PopupButtonID="ImageButton1" TargetControlID="txt_Lrdate" >
 </ajaxtoolkit:calendarextender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" validationGroup="bill" runat="server" ErrorMessage="Enter LRDate" controlToValidate="txt_Lrdate" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Agreement Value
                <br />
                <asp:TextBox ID="txt_Agreementvalue" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" validationGroup="bill" runat="server" ErrorMessage="Enter Agreementvalue" controlToValidate="txt_Agreementvalue" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Other Charges
                <br />
                <asp:TextBox ID="txt_Othercharges" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" validationGroup="bill" runat="server" ErrorMessage="Enter Othercharges" controlToValidate="txt_Othercharges" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr  style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
            <td>
                <br />
                Basic Freight
                <br />
                <asp:TextBox ID="txt_Basicfreight" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" validationGroup="bill" runat="server" ErrorMessage="Enter Basicfreight" controlToValidate="txt_Basicfreight" style="Color:red;"></asp:RequiredFieldValidator>
                <br />
                  <br />
            </td>
            <td>
                Loading Dentention
                <br />
                <asp:TextBox ID="txt_Loadingdetention" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" validationGroup="bill" runat="server" ErrorMessage="Enter Loadingdentention" controlToValidate="txt_Loadingdetention" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Unloading Dentention
                <br />
                <asp:TextBox ID="txt_Unloadingdetention" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" validationGroup="bill" runat="server" ErrorMessage="Enter Unloadingdentention" controlToValidate="txt_Unloadingdetention" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Octroid
                <br />
                <asp:TextBox ID="txt_Octroid" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" validationGroup="bill" runat="server" ErrorMessage="Enter Octroid" controlToValidate="txt_Octroid" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr  style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
            <td>
                <br />
                Loading Charges
                <br />
                <asp:TextBox ID="txt_Loadingcharges" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" validationGroup="bill" runat="server" ErrorMessage="Enter Loadingcharges" controlToValidate="txt_Loadingcharges" style="Color:red;"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
            <td>
                Unloading Charges
                <br />
                <asp:TextBox ID="txt_Unloadingcharges" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" validationGroup="bill" runat="server" ErrorMessage="Enter Unloadingcharges" controlToValidate="txt_Unloadingcharges" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Dimension Difference
                <br />
                <asp:TextBox ID="txt_Dimensiondiff" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" validationGroup="bill" runat="server" ErrorMessage="Enter Dimensiondifference" controlToValidate="txt_Dimensiondiff" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
            <td>
                Other Claims
                <br />
                <asp:TextBox ID="txt_Otherclaims" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" validationGroup="bill" runat="server" ErrorMessage="Enter Otherclaims" controlToValidate="txt_Otherclaims" style="Color:red;"></asp:RequiredFieldValidator>
            </td>
        </tr>

         <tr  style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
            <td>
                <br />
                Insurance
                <br />
                <asp:TextBox ID="txt_Insurance" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" validationGroup="bill" runat="server" ErrorMessage="Enter Insurance" controlToValidate="txt_Insurance" style="Color:red;"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
            <td>
                Damages
                <br />
                <asp:TextBox ID="txt_Damages" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" validationGroup="bill" runat="server" ErrorMessage="Enter Damages" controlToValidate="txt_Damages" style="Color:red;"></asp:RequiredFieldValidator>
             </td>
            <td>
                Shortages
                <br />
                <asp:TextBox ID="txt_Shortages" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" validationGroup="bill" runat="server" ErrorMessage="Enter Shortages" controlToValidate="txt_Shortages" style="Color:red;"></asp:RequiredFieldValidator>
             </td>
            <td>
                
             </td>
        </tr>

        <tr  style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
            <td colspan ="4">
          <center >     
              <br />
              <asp:Button id="btn_Edit" runat="server" Text="Edit" validationGroup="bill" OnClick="btn_Edit_Click"  Class="btn btn-primary"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btn_Delete" runat="server" Text="Delete" OnClick="btn_Delete_Click" Class="btn btn-primary"/>
                <br />
                <br />
                </center> 

            </td>
        </tr>
        </table> 
        </div>
</asp:Content>

