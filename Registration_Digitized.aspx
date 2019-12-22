<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Registration_Digitized.aspx.cs" Inherits="Registration_Digitized"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
 
    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
<meta name="keywords" content="SCM Bizconnect ESignature  Logistics"  />
	<meta name="description" content="SCM Junction is an initiative from AARM SCM Solutions Pvt. Ltd., Bengaluru, India; to build a logistics open platform to match supply and demand of road transportation in India." />

	<meta name="author" content="AARM SCM Solutions Pvt. Ltd." />
	<meta name="robots" content="ALL"/>
	<meta name="revisit-after" content="1 days"/>
	<meta name="classification" content="Website, Corporate"/>
	<meta name="distribution" content="Global"/>
	<meta name="rating" content="General"/>
	<meta name="copyright" content="Copyright (C) 2010, AARMSCM Solutions Pvt. Ltd." />
	<meta name="language" content="English"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <br /><br /><br /><br /><br /><br />
    <div style="margin-left:400px"> 
        <table >
        <tr>
  <td colspan="2">
            <div class="title-one" style="margin-left:120px">
					Registration<%--<div id="column_left" style="right: 450px; top: 60px" >
                        </div>--%>
				</div>
      <br />
            <span style="color: #ff0000">* <span style="color: #000000">indicates mandatory</span></span>
		            <div class="frmsubHeadRow" style="color: #000000"> 
					            &nbsp;&nbsp;<asp:Label ID="lblmsg" runat="server" ForeColor="Red" ></asp:Label></div>
            </td>
        </tr>
        <tr>
     
            <td style="width: 100px">
               <div class="frmTblRow">
                <strong>First Name</strong><span style="color: #ff0000">*</span><br/>
                        <asp:DropDownList ID="Drp_salutation" runat="server" Width="49px" CssClass="frmTxt">
                            <asp:ListItem>Mr.</asp:ListItem>
                            <asp:ListItem>Mrs.</asp:ListItem>
                            <asp:ListItem>Ms.</asp:ListItem>
                         
                        </asp:DropDownList>&nbsp;<asp:TextBox ID="Txt_fname" runat="server" 
                            cssclass="frmTxt" Width="147px" onKeyPress="return onlyalpha(event)" 
                            ValidationGroup="reg"></asp:TextBox><br />
			  			<div class="helptext">No Space,No Special Character allowed</div>
                   <asp:RequiredFieldValidator ID="Req_Fname" runat="server" ControlToValidate="txt_fname"
                                ErrorMessage="Enter First Name" CssClass="frmTblRowErr" Width="118px" ValidationGroup="Reg2" ></asp:RequiredFieldValidator>
             </div>
            </td>
         
            	
            <td style="width: 100px">
                <div class="frmTblRow" >
                    <strong>Last Name</strong><span style="color: #ff0000">*</span><br/>
						 <asp:TextBox ID="txt_lname" runat="server" cssclass="frmTxt" onKeyPress="return onlyalpha(event)" ValidationGroup="reg"></asp:TextBox>
                      <div class="helptext">No Space,No Special Character allowed</div>
                    <asp:RequiredFieldValidator ID="Req_Lname" runat="server" ControlToValidate="txt_lname"
                                ErrorMessage="Enter Last Name" CssClass="frmTblRowErr" Width="122px" ValidationGroup="Reg2"></asp:RequiredFieldValidator>
						
            </div>
            </td>
            
        </tr>
        <tr >
            <td style="width: 100px; height: 83px;">
            <div class="frmTblRow" >
                <strong>
                        Designation</strong><span style="color: #ff0000">*</span><br />
                    <asp:TextBox ID="Txt_designation" runat="server" CssClass="frmTxt" onkeypress="return onlyalphawithspace(event)"
                        ValidationGroup="reg"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="Req_Designation" runat="server" ControlToValidate="txt_designation"
                        CssClass="frmTblRowErr" ErrorMessage="Enter designtion" ValidationGroup="Reg2"
                        Width="97px"></asp:RequiredFieldValidator><br />
                         </div>
            </td>
           
            <td style="width: 100px; height: 83px">
            </td>
        </tr>
        <tr><td colspan="2" ><hr /></td></tr>
        <tr>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <b>Email Address</b><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_email" runat="server" CssClass="frmTxt" ValidationGroup="reg" onkeypress="return nospace1(event)"></asp:TextBox>
                      <div class="helptext">eg.:abc123@gmail.com<br /> </div>
                    <asp:RequiredFieldValidator ID="Req_Email" runat="server" ControlToValidate="txt_email"
                        CssClass="frmTblRowErr" ErrorMessage="Enter email address" ValidationGroup="Reg2"
                        Width="118px"></asp:RequiredFieldValidator><br />
                  
                    <asp:RegularExpressionValidator ID="REV_Emailid"
                            runat="server" ControlToValidate="txt_email" CssClass="frmTblRowErr" ErrorMessage="Invalid email-ID"
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="Reg2" Width="111px"></asp:RegularExpressionValidator></div>
                </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                        <b>
                            Password</b><span style="color: #ff0000">*</span><br/>
						
						<asp:TextBox ID="txt_password" runat="server" cssclass="frmTxt" TextMode="Password"  ValidationGroup="reg" onkeypress="return nospace1(event)"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="Req_password" runat="server" ControlToValidate="txt_Password"
                                ErrorMessage="Enter password" CssClass="frmTblRowErr" Width="97px" ValidationGroup="Reg2"></asp:RequiredFieldValidator><asp:CustomValidator ID="CusPassword"
                                    runat="server" ClientValidationFunction="validateLength" ControlToValidate="Txt_password"
                                    ErrorMessage="Password too short" CssClass="frmTblRowErr" Width="142px" ValidationGroup="Reg2"></asp:CustomValidator>
						<br />
					</div>
            </td>
        </tr>
        
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Mobile No<br />
                </strong>
                    <asp:TextBox ID="txt_Mobile" runat="server" AutoCompleteType="none" CssClass="frmTxt" MaxLength="10" onkeypress="return onlynumber(event)"
                        ValidationGroup="reg"></asp:TextBox><br /><br />
                    <asp:RegularExpressionValidator ID="Regexp_mobile" runat="server" ControlToValidate="txt_Mobile"
                        CssClass="frmTblRowErr" ErrorMessage="Invalid mobile No." Font-Names="Arial"
                        ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="Reg2"
                        Width="153px"></asp:RegularExpressionValidator>
                    <div class="helptext">
                        Should be a 10 digit number</div>
                        </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong>
                            Phone No</strong>
                        <br/>
						 <asp:TextBox ID="Txt_Phone" runat="server" cssclass="frmTxt" onKeyPress="return onlynumber(event)" MaxLength="12"></asp:TextBox>
                        <asp:Label id="lblerrormsg" runat="server" Text="Enter mobile or phone no" Visible="False" CssClass="frmTblRowErr" Width="159px" ></asp:Label>
                       
                        </div>
            </td>
        </tr>
             <tr><td colspan="2" ><hr /></td></tr>
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
						                    <strong>Corporate Address</strong><span style="color: #ff0000">*</span><br/>
						 <asp:TextBox ID="Txt_address" runat="server" cssclass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="Req_Address" runat="server" ControlToValidate="txt_address"
                                ErrorMessage="Enter address " CssClass="frmTblRowErr" Width="86px" ValidationGroup="Reg2"></asp:RequiredFieldValidator><br />

					
					</div>
					
            </td>
            <td style="width: 100px">
            	<div class="frmTblRow">
                    <strong>Area</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="Txt_area" runat="server" CssClass="frmTxt" ValidationGroup="Reg2"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="Reqarea" runat="server" ControlToValidate="txt_area"
                        CssClass="frmTblRowErr" ErrorMessage="Enter area " ValidationGroup="Reg2"
                        Width="68px"></asp:RequiredFieldValidator><br />
					</div>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>City</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="Txt_city" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" onkeypress="return onlyalphawithspace(event)"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="Req_city" runat="server" ControlToValidate="txt_city"
                        CssClass="frmTblRowErr" ErrorMessage="Enter city" ValidationGroup="Reg2" Width="63px"></asp:RequiredFieldValidator><br />
           </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong>Pincode</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_pincode" runat="server" CssClass="frmTxt" MaxLength="6" onkeypress="return onlynumber(event)"
                        ValidationGroup="Reg2"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="Req_pin" runat="server" ControlToValidate="txt_pincode"
                        CssClass="frmTblRowErr" ErrorMessage="Enter pincode" ValidationGroup="Reg2" Width="89px"></asp:RequiredFieldValidator><br />
                </div>
            </td>
        </tr>
             <tr><td colspan="2" ><hr /></td></tr>
        <tr>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong>Company Name</strong><span style="color: #ff0000">*</span><br />
                    <asp:TextBox ID="Txt_companyname" runat="server" CssClass="frmTxt" ValidationGroup="reg" onkeypress="return onlyalphawithspace(event)"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="Req_company" runat="server" ControlToValidate="Txt_companyname"
                        CssClass="frmTblRowErr" ErrorMessage="Enter company name" ValidationGroup="Reg2"
                        Width="132px"></asp:RequiredFieldValidator>&nbsp;</div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong>Company Website</strong>
                <br/>
						 <asp:TextBox ID="txt_url" runat="server" AutoCompleteType="none" cssclass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
						 <div class="helptext"> eg:.www.scmbizconnect.com</div>
                        <asp:RegularExpressionValidator ID="Reg_Exp_URL" runat="server" ControlToValidate="txt_url"
                            CssClass="frmTblRowErr" ErrorMessage="Enter valid URL" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"
                            Width="152px" ValidationGroup="Reg2"></asp:RegularExpressionValidator>
                   <br />
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <div class="frmTblRow">
                <strong>E-Signature</strong><span style="color: #ff0000">*</span><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator ID="Req_empno" runat="server" ControlToValidate="FileUpload1"
                        CssClass="frmTblRowErr" ErrorMessage="Choose file for upload" ValidationGroup="Reg2"
                        Width="138px"></asp:RequiredFieldValidator><br />
                        </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Enter the Below Code</strong><span style="color: #ff0000">*</span><br />
                    <asp:TextBox ID="Txt_Vcode" runat="server" CssClass="frmTxt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_Vcode"
                        CssClass="frmTblRowErr" ErrorMessage="Enter the Code" ValidationGroup="Reg2"
                        Width="97px"></asp:RequiredFieldValidator><div class="frmTblRow">
                    &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/NewCaptcha.aspx" Width="180px" />
                    <br />
                    </div>
                    </div>
            </td>
        </tr>
       
             <tr><td colspan="2" ><hr /></td></tr>
        <tr>
            <td colspan="2">
              
                <div   class="frmTblRow" style="text-align: center">
                    <asp:Button ID="Btn_submit" runat="server" Class="btn btn-primary" Text="Submit" 
                        ValidationGroup="Reg2" onclick="Btn_submit_Click" />
                    </div>
            </td>
    </table>
        </div>

    <br /><br /><br /><br /><br /><br />
</asp:Content>

