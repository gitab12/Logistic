<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="AddBranches.aspx.cs" Inherits="AddBranches" %>

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
<br />
     <div style="margin-left:300px">
    <div class ="mapouterdiv" >
          <div class ="mapinnerdiv" >
<asp:Panel ID="pnlbtn" runat="server" Width="60%" >
    <br />
    <asp:RadioButton ID="client" runat="server" Text="Client" AutoPostBack="true" Font-Bold="true"  Font-Size="16px" oncheckedchanged="client_CheckedChanged" CssClass="frmTblRow" style="color:Red"/>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
    <asp:RadioButton ID="customer" runat="server" Text="Customer" AutoPostBack="true" Font-Bold="true" Font-Size="16px" oncheckedchanged="customer_CheckedChanged" CssClass="frmTblRow" style="color:Red"/>
    </asp:Panel>
                      <asp:Label ID="lblmsg" runat="server" Visible="false" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="12pt" ForeColor="Red"></asp:Label>
   <br />
    <asp:Panel ID="Panel1" runat="server" Width="60%" GroupingText="Client Details">
        <asp:Label ID="lblclientname" runat="server" CssClass="frmTblRow" Font-Bold="true" Font-Size="14px" Text="ClientName :" style="color:Red"></asp:Label>&nbsp;
        <asp:Label ID="lblcname" runat="server" CssClass="frmTblRow" Font-Bold="true" Font-Size="14px" style="color:Red"></asp:Label><br />
        <br />
        <asp:Label ID="lblcustomername" runat="server" CssClass="frmTblRow" Font-Bold="true" Font-Size="14px" Text="Select CustomerName :" Visible="false" style="color:Red"></asp:Label>&nbsp;
        <asp:DropDownList ID="ddlcustname" runat="server" CssClass="frmTxt" 
            Height="25px" Width="212px" Visible="false" AutoPostBack="true" 
            onselectedindexchanged="ddlcustname_SelectedIndexChanged"></asp:DropDownList>&nbsp;
</asp:Panel>

     <table width="70%">
         <br />
          <tr>
            <td style="width: 100px" colspan="2">
            <div class="frmTblRow">
                <strong style="color:Red">Location Type</strong><br />
                <asp:DropDownList
                        ID="DDLLocation" runat="server" CssClass="frmTxt" Height="25px" 
                    Width="212px">
                 
                </asp:DropDownList>
                </div>
                </td>
            </tr>
             <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Contact Person
                </strong><span style="color: #ff0000">*</span>
                    <asp:TextBox ID="txt_cperson" runat="server"  CssClass="frmTxt" onkeypress="return onlyalphawithspace(event)"
                        ValidationGroup="reg"></asp:TextBox><br />
              
                        <asp:RequiredFieldValidator ID="req_cperson" runat="server" ControlToValidate="txt_cperson"
                               CssClass="frmTblRowErr" ErrorMessage="Enter Contact Person Name" ValidationGroup="Reg2"
                                  Width="222px"   style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ></asp:RequiredFieldValidator><br />
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                 <strong style="color:Red">Designation</strong><br/>
					<asp:DropDownList ID="ddldesg" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
            </div>
            </td>
        </tr>
           <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Board No<br />
                </strong>
                    <asp:TextBox ID="txt_Boardno" runat="server" MaxLength="12" AutoCompleteType="none" CssClass="frmTxt" onkeypress="return onlynumber(event)"
                        ValidationGroup="reg" value="0" onblur="if(this.value=='') this.value='0';" onfocus="if(this.value=='0') this.value='';"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong style="color:Red"> Fax</strong>
                        <br/>
						 <asp:TextBox ID="Txt_fax" runat="server" MaxLength="12" cssclass="frmTxt"  value="0" onblur="if(this.value=='') this.value='0';" onfocus="if(this.value=='0') this.value='';"></asp:TextBox>
                      
                        </div>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Corporate Email ID</strong><span style="color: #ff0000">*</span><br/>
                <asp:TextBox ID="txt_Email" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Email"
                    ErrorMessage="Enter Email ID"   style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"  ValidationGroup="Reg2">Enter Email ID</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Email"
                    ErrorMessage="Enter valid Email ID"   style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="156px"></asp:RegularExpressionValidator></div>
					
            </td>
            <td style="width: 100px">
            	<div class="frmTblRow">
                    <strong style="color:Red">Address</strong><span style="color: #ff0000">*</span><br/>
						 <asp:TextBox ID="Txt_address" runat="server" cssclass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br /><br />
                <asp:RequiredFieldValidator ID="Req_Address" runat="server" ControlToValidate="txt_address"
                                ErrorMessage="Enter address "    style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" CssClass="frmTblRowErr" Width="86px" ValidationGroup="Reg2"></asp:RequiredFieldValidator><br />
					</div>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">City</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:DropDownList ID="ddlcity" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList><br />
                   
           </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">State </strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="Txt_state" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="Reqarea" runat="server" ControlToValidate="Txt_state"
                        CssClass="frmTblRowErr" ErrorMessage="Enter state " ValidationGroup="Reg2"
                        Width="68px" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ></asp:RequiredFieldValidator><br />
                </div>
            </td>
        </tr>
      <tr>
          <td style="width: 100px">
          <div class="frmTblRow">
              <strong style="color:Red">Country</strong><span style="color: #ff0000">*</span>
              <br />
              <asp:TextBox ID="Txt_country" runat="server" CssClass="frmTxt"  
                  ValidationGroup="Reg2"></asp:TextBox><br />
              <br />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_country"
                  CssClass="frmTblRowErr" ErrorMessage="Enter Country name" ValidationGroup="Reg2"
                  Width="149px" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ></asp:RequiredFieldValidator><br />
                  </div>
          </td>
          <td style="width: 100px">
          <div class="frmTblRow">
              <strong style="color:Red">Pincode</strong><span style="color: #ff0000">*</span>
              <br />
              <asp:TextBox ID="txt_pincode" runat="server" CssClass="frmTxt" MaxLength="6" onkeypress="return onlynumber(event)"
                  ValidationGroup="Reg2"></asp:TextBox><br />
              <br />
              <asp:RequiredFieldValidator ID="Req_pin" runat="server" ControlToValidate="txt_pincode"   style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                  CssClass="frmTblRowErr" ErrorMessage="Enter pincode" ValidationGroup="Reg2" Width="89px"></asp:RequiredFieldValidator><br />
        </div>
          </td>
      </tr>
      <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Mobile Number</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_Mobile" runat="server" CssClass="frmTxt" MaxLength="10" 
                        onkeypress="return onlynumber(event)" ValidationGroup="reg"></asp:TextBox>
                    <div style="font-size:11px;color:#ff0000;font-style:italic;display:block;height: 33px;">
                        &nbsp;Should be a 10 digit number</div>
                    <asp:RegularExpressionValidator ID="Regexp_mobile" runat="server" 
                        ControlToValidate="txt_Mobile" CssClass="frmTblRowErr" 
                        ErrorMessage="Invalid mobile No." Font-Names="Arial" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="Reg2" 
                        Width="208px"></asp:RegularExpressionValidator>
                </div>
                <br />
                
            </td>
        </tr>
           <asp:Panel ID="Pnldisp" runat="server" Visible="false">
        <tr><td colspan="2" ><hr /><b style="color: #003366;font-size:14px;font-family:@Arial Unicode MS">Personal&nbsp; Details</b></td></tr>
     
              <tr>
         <td class="style1">
            <div class="frmTblRow">
                <strong style="color:Red">Login Email ID</strong><span style="color: #ff0000">*</span><br/>
                <asp:TextBox ID="txt_loginid" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_loginid"
                    ErrorMessage="Enter Email ID" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS">Enter Email ID</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_loginid"
                    ErrorMessage="Enter valid Email ID" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"
                    Width="222px"></asp:RegularExpressionValidator></div>
					
            </td>
            <td class="style1">
            <div class="frmTblRow">
               <b style="color:Red">Password</b><span style="color: #ff0000">*</span><br/>
				<asp:TextBox ID="txt_password" runat="server" cssclass="frmTxt" TextMode="Password"  ValidationGroup="reg"></asp:TextBox>
				<asp:RequiredFieldValidator ID="Req_password" runat="server" ControlToValidate="txt_Password"
                                ErrorMessage="Enter password" CssClass="frmTblRowErr" Width="97px" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"></asp:RequiredFieldValidator><br />
                <asp:CustomValidator ID="CusPassword" runat="server" ClientValidationFunction="validateLength" ControlToValidate="Txt_password"
                                    ErrorMessage="Password too short" CssClass="frmTblRowErr" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"></asp:CustomValidator>
					</div>
            </td>
      </tr>
        <tr>
            <td class="style1">
               <div class="frmTblRow">
                    <strong style="color:Red">First Name</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_firstname" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalphawithspace(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txt_firstname" CssClass="frmTblRowErr" ErrorMessage="Enter first name" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="218px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Middle Name </strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_middlename" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalphawithspace(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txt_middlename" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter middle name" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="210px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
        </tr>
             <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Last Name</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_lastname" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalphawithspace(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txt_lastname" CssClass="frmTblRowErr" ErrorMessage="Enter last name" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="218px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Department </strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_dept" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalphawithspace(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txt_dept" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter Department" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="210px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Age</strong><span style="color: #ff0000">*</span><br/>
                    <asp:TextBox ID="txt_age" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlynumber(event)" ValidationGroup="reg" MaxLength="3"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txt_age" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter Age" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="222px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Designation</strong><br />
                    <asp:DropDownList ID="ddldesgreg" runat="server" 
                        CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Phone Number</strong><span style="color: #ff0000">*</span>
                    <asp:TextBox ID="txt_phone" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlynumber(event)" ValidationGroup="reg" MaxLength="12"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txt_phone" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter Phone Number" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="222px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Gender</strong><br />
                    <asp:DropDownList ID="ddlgender" runat="server" 
                        CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
           <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Mobile Number</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_mobl" runat="server" CssClass="frmTxt" MaxLength="10" 
                        onkeypress="return onlynumber(event)" ValidationGroup="reg"></asp:TextBox>
                    <div style="font-size:11px;color:#ff0000;font-style:italic;display:block;height: 33px;">
                        &nbsp;Should be a 10 digit number</div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txt_mobl" CssClass="frmTblRowErr" 
                        ErrorMessage="Invalid mobile No." Font-Names="Arial" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="Reg2" 
                        Width="208px"></asp:RegularExpressionValidator>
                </div>
                <br />
                </div>
            </td>
        </tr>  
        </asp:Panel>
   
       <tr><td colspan="2"><hr /></td></tr>
       
            
        <tr>
            <td colspan="2">
              
                <div   class="frmTblRow" style="text-align: center">
                    <asp:Button ID="Btn_submit" runat="server" Text="Submit" 
                        ValidationGroup="Reg2" onclick="Btn_submit_Click"  Class="btn btn-primary"/><br/>
                </div>
                
            </td>
        </tr>
        </table>
             
            </div> 
    </div> 
   

</asp:Content>


