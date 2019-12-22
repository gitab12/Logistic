<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EditClient.aspx.cs" Inherits="EditClient"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br/>
    <br /><br /><br /><br /><br /><br />
    <div style="margin-left:300px">
<asp:Panel ID="Panel1" runat="server" Font-Bold="true">
 <asp:Label ID="lblid" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" ForeColor="Red" Width="72px" Text="Client ID:"></asp:Label>
 <asp:Label ID="lblaid" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" ForeColor="Red" Width="308px"></asp:Label>
    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" 
        Font-Size="10pt" Width="272px"></asp:Label>
  <table width="70%">
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Company Name</strong><span style="color: #ff0000">*</span><br/>
                    <asp:TextBox ID="Txt_companyname" runat="server" CssClass="frmTxt" ValidationGroup="reg"></asp:TextBox><br/>
                    <asp:RequiredFieldValidator ID="Req_company" runat="server" ControlToValidate="Txt_companyname" CssClass="frmTblRowErr" ErrorMessage="Enter company name" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" Width="200px"></asp:RequiredFieldValidator><br/>
                    </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>
                    <br/>
                    <br/>
                    <br/>Company Website</strong>
                <br/>
						 <asp:TextBox ID="txt_url" runat="server" AutoCompleteType="none" cssclass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
						 <div class="helptext"> eg:.www.bizconnect.com</div><br/>
                        <asp:RegularExpressionValidator ID="Reg_Exp_URL" runat="server" ControlToValidate="txt_url" CssClass="frmTblRowErr" ErrorMessage="Enter valid URL" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" Width="152px" ValidationGroup="Reg2"></asp:RegularExpressionValidator>
                </div>
            </td>
        </tr>
      <tr>
          <td>
          <div class="frmTblRow">
              <strong>No of Employees<br/>
              </strong><asp:TextBox ID="txt_noE" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br/>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_noE" ErrorMessage="Enter Only Digits" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
              </div>
          </td>
          <td>
          <div class="frmTblRow">
              <strong>Year of Establishment</strong>
              <br/>
              <asp:TextBox ID="Txt_YOE" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="4"></asp:TextBox><br/>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="Txt_YOE" ErrorMessage="Enter Only Digits" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
          </div> 
          </td>
      </tr>
      <tr>
          <td>
          <div class="frmTblRow">
              <strong>PAN No</strong><span style="color: #ff0000">*</span>
              <br/>
              <asp:TextBox ID="txt_pno" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="15"></asp:TextBox><br/>
              <asp:RequiredFieldValidator ID="Req_pno" runat="server" ControlToValidate="txt_pno" CssClass="frmTblRowErr" ErrorMessage="Enter your Pan Number" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" Width="200px"></asp:RequiredFieldValidator><br/>
                  </div>
          </td>
          <td>
          <div class="frmTblRow">
              <strong>TIN No</strong><span style="color: #ff0000">*</span>
              <br/>
              <asp:TextBox ID="txt_tno" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="20"></asp:TextBox><br/>
              <asp:RequiredFieldValidator ID="Req_tno" runat="server" ControlToValidate="txt_tno" CssClass="frmTblRowErr" ErrorMessage="Enter your Tin Number" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" Width="200px"></asp:RequiredFieldValidator><br/>
          </div> 
          </td>
      </tr>
      <tr>
          <td>
          <div class="frmTblRow">
              <strong>CENVAT Reg No</strong><span style="color: #ff0000">*</span>
              <br/>
              <asp:TextBox ID="txt_cenvat" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="20"></asp:TextBox><br/>

              <asp:RequiredFieldValidator ID="Req_cenvat" runat="server" ControlToValidate="txt_cenvat" CssClass="frmTblRowErr" ErrorMessage="Enter your CENVAT Reg Number" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" Width="184px"></asp:RequiredFieldValidator><br/>
                  </div>
          </td>
          <td>
          <div class="frmTblRow">
              <strong>Service Tax Reg No</strong><span style="color: #ff0000">*</span>
              <br/>
              <asp:TextBox ID="txt_stax" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="20"></asp:TextBox><br/>
              <asp:RequiredFieldValidator ID="Req_stax" runat="server" ControlToValidate="txt_stax" CssClass="frmTblRowErr" ErrorMessage="Enter your Service Tax Number" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" Width="264px"></asp:RequiredFieldValidator><br/>
          </div> 
          </td>
      </tr>
        <tr>
            <td>
            <div class="frmTblRow">
                <strong>Location Type</strong><br/>
                <asp:DropDownList ID="DDLLocation" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    <asp:ListItem Value="1">HeadOffice</asp:ListItem>
                </asp:DropDownList>
                </div>
                </td>
            <td>
                <div class="frmTblRow">
                    <strong>Annual TurnOver</strong><br/>
                    <asp:TextBox ID="txt_Annualturnover" runat="server" CssClass="frmTxt" Width="135px"></asp:TextBox>
                    <asp:DropDownList ID="ddl_trnover" runat="server" CssClass="frmTxt" Height="25px" Width="67px">
                        <asp:ListItem>Lakhs</asp:ListItem>
                        <asp:ListItem>Crores</asp:ListItem>
                    </asp:DropDownList></div>
            </td>
        </tr>
        
      <tr>
          <td colspan="2"><hr/> <b style="color: #003366;font-size:14px;font-family:@Arial Unicode MS">Company Contact Details</b></td>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Contact Person </strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_cperson" runat="server" CssClass="frmTxt" ValidationGroup="reg"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_cperson" runat="server" ControlToValidate="txt_cperson" CssClass="frmTblRowErr" ErrorMessage="Enter Contact Person Name" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="222px"></asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Designation</strong><br/>
                    <asp:DropDownList ID="ddldesg" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Board No </strong><span style="color: #ff0000">*</span><br/>
                    <asp:TextBox ID="txt_Boardno" runat="server" AutoCompleteType="none"  CssClass="frmTxt" MaxLength="12"  ValidationGroup="reg"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_bno" runat="server" ControlToValidate="txt_cperson" CssClass="frmTblRowErr" ErrorMessage="Enter Board Number" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="236px"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_Boardno" ErrorMessage="Enter Only Digits" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Fax</strong>
                    <br/>
                    <asp:TextBox ID="Txt_fax" runat="server" cssclass="frmTxt" MaxLength="12"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Corporate Email ID</strong><span style="color: #ff0000">*</span><br/>
                    <asp:TextBox ID="txt_Email" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Email" ErrorMessage="Enter Email ID" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2">Enter Email ID</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Email" ErrorMessage="Enter valid Email ID" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="204px"></asp:RegularExpressionValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Address</strong><span style="color: #ff0000">*</span><br/>
                    <asp:TextBox ID="Txt_address" runat="server" cssclass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Req_Address" runat="server" ControlToValidate="txt_address" CssClass="frmTblRowErr" ErrorMessage="Enter address " style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="209px"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>City</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="Txt_city" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Req_city" runat="server" ControlToValidate="txt_city" CssClass="frmTblRowErr" ErrorMessage="Enter city" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="218px"></asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>State</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="Txt_state" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Reqarea" runat="server" ControlToValidate="Txt_state" CssClass="frmTblRowErr" ErrorMessage="Enter area " style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="210px"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Country</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="Txt_country" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_country" CssClass="frmTblRowErr" ErrorMessage="Enter Country name" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="215px"></asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Pincode</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="txt_pincode" runat="server" CssClass="frmTxt" MaxLength="6" ValidationGroup="Reg2"></asp:TextBox>
                    <br/>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="Txt_pincode" ErrorMessage="Enter Only Digits" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="Req_pin" runat="server" ControlToValidate="txt_pincode" CssClass="frmTblRowErr" ErrorMessage="Enter pincode" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="99px"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Mobile Number</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="txt_Mobile" runat="server" CssClass="frmTxt" MaxLength="10" ValidationGroup="reg"></asp:TextBox>
                    <div style="font-size:11px;color:#ff0000;font-style:italic;display:block;height: 33px;"> &nbsp;Should be a 10 digit number<br/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txt_Mobile" ErrorMessage="Enter Valid Number" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                    </div>
                    <asp:RegularExpressionValidator ID="Regexp_mobile" runat="server" ControlToValidate="txt_Mobile" CssClass="frmTblRowErr" ErrorMessage="Invalid mobile No." Font-Names="Arial" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="Reg2" Width="99px"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txt_phone" ErrorMessage="Enter Only Digits" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                </div>
            </td>
        </tr>
          <tr><td colspan="2"><hr/><b style="color: #003366;font-size:14px;font-family:@Arial Unicode MS">Personal&nbsp; Details</b></td></tr>
      <tr>
         <td>
            <div class="frmTblRow">
                <strong>Login Email ID</strong><span style="color: #ff0000">*</span><br/>
                <asp:TextBox ID="txt_loginid" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_loginid" ErrorMessage="Enter Email ID" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS">Enter Email ID</asp:RequiredFieldValidator><br/>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_loginid" ErrorMessage="Enter valid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" Width="152px"></asp:RegularExpressionValidator></div>
					
            </td>
            <td>
            <div class="frmTblRow">
               <b>Password</b><span style="color: #ff0000">*</span><br/>
				<asp:TextBox ID="txt_password" runat="server" cssclass="frmTxt"  
                    ValidationGroup="reg"></asp:TextBox>
				<asp:RequiredFieldValidator ID="Req_password" runat="server" ControlToValidate="txt_Password" ErrorMessage="Enter password" CssClass="frmTblRowErr" Width="97px" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"></asp:RequiredFieldValidator><br/>
                
                <asp:CustomValidator ID="CusPassword" runat="server" ClientValidationFunction="validateLength" ControlToValidate="Txt_password" ErrorMessage="Password too short" CssClass="frmTblRowErr" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"></asp:CustomValidator>
					</div>
            </td>
      </tr>
        <tr>
            <td>
               <div class="frmTblRow">
                    <strong>First Name</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="txt_firstname" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_firstname" CssClass="frmTblRowErr" ErrorMessage="Enter first name" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="218px"></asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Middle Name</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="txt_middlename" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_middlename" CssClass="frmTblRowErr" ErrorMessage="Enter middle name" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="210px"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
             <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Last Name</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="txt_lastname" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_lastname" CssClass="frmTblRowErr" ErrorMessage="Enter last name" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="173px"></asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Department</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="txt_dept" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_dept" CssClass="frmTblRowErr" ErrorMessage="Enter Department" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="210px"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Age</strong><span style="color: #ff0000">*</span><br/>
                    <asp:TextBox ID="txt_age" runat="server" CssClass="frmTxt" ValidationGroup="reg" MaxLength="3"></asp:TextBox>
                     <br/>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="Txt_age" ErrorMessage="Enter Only Digits" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                     &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_age" CssClass="frmTblRowErr" ErrorMessage="Enter Age" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="102px"></asp:RequiredFieldValidator></div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Designation</strong><br/>
                    <asp:DropDownList ID="ddldesgreg" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Phone Number</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_phone" runat="server" CssClass="frmTxt" ValidationGroup="reg" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_phone" CssClass="frmTblRowErr" ErrorMessage="Enter Phone Number" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationGroup="Reg2" Width="119px" Height="18px"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txt_phone" ErrorMessage="Enter Only Digits" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                </div>
            </td>
            <td>
                <div class="frmTblRow">
                    <strong>Gender</strong><br/>
                    <asp:DropDownList ID="ddlgender" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
           <tr>
            <td>
                <div class="frmTblRow">
                    <strong>Mobile Number</strong><span style="color: #ff0000">*</span>
                    <br/>
                    <asp:TextBox ID="txt_mobl" runat="server" CssClass="frmTxt" MaxLength="10" ValidationGroup="reg"></asp:TextBox>
                    <div style="font-size:11px;color:#ff0000;font-style:italic;display:block;"> &nbsp;Should be a 10 digit number<br/>
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_mobl" CssClass="frmTblRowErr" ErrorMessage="Invalid mobile No." Font-Names="Arial" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="Reg2" Width="103px"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txt_mobl" ErrorMessage="Enter Valid Number" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
            </td>
        </tr>     
        <tr>
            <td colspan="2">
                <hr/>
                  <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Update" Class="btn btn-primary"/>
            </td>
        </tr>
        </table>
       
    </asp:Panel>

        </div>
     <br /><br /><br /><br /><br /><br />
</asp:Content>

