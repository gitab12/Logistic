<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="Transporter.aspx.cs" Inherits="Transporter"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
          <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
 <style type="text/css">
        .style1
        {
            width:67px;
        }
        .style2
        {
            height: 27px;
        }
        .style3
        {
            width: 100px;
            height: 27px;
        }

              
        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :550px;
    height :1190px;
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
    height :1180px;
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
  <table width="70%" >
     <br />
        <tr>
            <td class="style2" >
                <asp:Label ID="lblid" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="12pt" ForeColor="Red" Text="Transporter ID :" Width="129px"></asp:Label>
                <asp:Label ID="lblaid" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="12pt" ForeColor="Red" Width="56px"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="12pt" ForeColor="Red" Visible="False" Width="256px"></asp:Label>
            </td>
            <td class="style3">
                <asp:Button ID="But_Addtransporter" runat="server" 
                    onclick="But_Addtransporter_Click" Text="Add Another Transporter" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Company Name</strong><span style="color: #ff0000">*</span><br />
                    <asp:TextBox ID="Txt_companyname" runat="server" CssClass="frmTxt" 
                        onFocus="doClear(this)" onKeyPress="return onlyalpha(event)" 
                        ValidationGroup="reg"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="Req_company" runat="server" 
                        ControlToValidate="Txt_companyname" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter company name" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="204px"></asp:RequiredFieldValidator>
                    <br />
                    &nbsp;</div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Company Website</strong>
                    <br />
                    <asp:TextBox ID="txt_url" runat="server" AutoCompleteType="none" 
                        cssclass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                    <div class="helptext">
                        eg:.www.bizconnect.com</div>
                    <br />
                    <asp:RegularExpressionValidator ID="Reg_Exp_URL" runat="server" 
                        ControlToValidate="txt_url" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter valid URL" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" 
                        ValidationGroup="Reg2" Width="152px"></asp:RegularExpressionValidator>
                    <br />
                </div>
            </td>
        </tr>
      <tr>
          <td class="style1">
          <div class="frmTblRow">
              <strong style="color:Red">Transporter Name</strong><span style="color: #ff0000">*</span><br />
              <asp:TextBox ID="txt_trname" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" onkeypress="return onlyalpha(event)"></asp:TextBox><br />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_trname"
                  CssClass="frmTblRowErr" ErrorMessage="Enter Transporter Name" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"
                  Width="216px"></asp:RequiredFieldValidator><br />
                  </div>
          </td>
          <td style="width: 100px">
          <div class="frmTblRow">
              <strong style="color:Red">Year of Establishment</strong>
              <br />
              <asp:TextBox ID="Txt_YOE" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" onkeypress="return onlynumber(event)" MaxLength="4"></asp:TextBox><br />
              <br />
              <br />
          </div> 
          </td>
      </tr>
      <tr>
          <td class="style1">
          <div class="frmTblRow">
              <strong style="color:Red">PAN No</strong><span style="color: #ff0000">*</span>
              <br />
              <asp:TextBox ID="txt_pno" runat="server"  CssClass="frmTxt" ValidationGroup="Reg" MaxLength="15" onkeypress="return nospace1(event)"></asp:TextBox><br />
         
              <asp:RequiredFieldValidator ID="Req_pno" runat="server" ControlToValidate="txt_pno"
                  CssClass="frmTblRowErr" ErrorMessage="Enter your Pan Number" ValidationGroup="Reg2" style="color: #003366;font-size:12px;font-family:@Arial Unicode MS"
                  Width="216px"></asp:RequiredFieldValidator><br />
                  </div>
          </td>
          <td style="width: 100px">
          <div class="frmTblRow">
              <strong style="color:Red">TIN No</strong>
              <br />
              <asp:TextBox ID="txt_tno" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="20"></asp:TextBox><br />
   
          
          </div> 
          </td>
      </tr>
      <tr>
          <td class="style1">
          <div class="frmTblRow">
              <strong style="color:Red">CENVAT Reg No</strong>
              <br />
              <asp:TextBox ID="txt_cenvat" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="20"></asp:TextBox><br />
      
            
                  </div>
          </td>
          <td style="width: 100px">
          <div class="frmTblRow">
              <strong style="color:Red">Service Tax Reg No</strong>
              <br />
              <asp:TextBox ID="txt_stax" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" MaxLength="20"></asp:TextBox><br />
     
         
          </div> 
          </td>
      </tr>
        <tr>
            <td class="style1">
            <div class="frmTblRow">
                <strong style="color:Red">Location Type</strong><br />
                <asp:DropDownList
                        ID="DDLLocation" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    <asp:ListItem Value="1">HeadOffice</asp:ListItem>
                </asp:DropDownList>
                </div>
                </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Annual TurnOver</strong><br />
                    <asp:TextBox ID="txt_Annualturnover" runat="server" CssClass="frmTxt" Width="135px" onkeypress="return onlynumber(event)"></asp:TextBox><asp:DropDownList
                        ID="ddl_trnover" runat="server" CssClass="frmTxt" Height="25px" Width="67px">
                        <asp:ListItem>Lakhs</asp:ListItem>
                        <asp:ListItem>Crores</asp:ListItem>
                    </asp:DropDownList></div>
            </td>
        </tr>
          <tr>
          <td class="style1">
          <div class="frmTblRow">
              <strong style="color:Red">No of Employees</strong><asp:TextBox ID="txt_noE" runat="server" CssClass="frmTxt" ValidationGroup="Reg2" onkeypress="return onlynumber(event)"></asp:TextBox><br />
              <br />
              <br />
                  </div>
          </td>
          </tr>
        
      <tr>
          <td colspan="2"><hr /> <b style="color: #003366;font-size:14px;font-family:@Arial Unicode MS">Company Contact Details</b></td>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Contact Person </strong><span style="color: #ff0000">*</span>
                    <asp:TextBox ID="txt_cperson" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalpha(event)" ValidationGroup="reg"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="req_cperson" runat="server" 
                        ControlToValidate="txt_cperson" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter Contact Person Name" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="222px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Designation</strong><br />
                    <asp:DropDownList ID="ddldesg" runat="server" 
                        CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Board No </strong><span style="color: #ff0000">*</span><br />
                    <asp:TextBox ID="txt_Boardno" runat="server" AutoCompleteType="none" 
                        CssClass="frmTxt" MaxLength="12" onkeypress="return onlynumber(event)" 
                        ValidationGroup="reg"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="req_bno" runat="server" 
                        ControlToValidate="txt_cperson" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter Board Number" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="236px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Fax</strong>
                    <br />
                    <asp:TextBox ID="Txt_fax" runat="server" cssclass="frmTxt" MaxLength="12" 
                        onkeypress="return onlynumber(event)"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Corporate Email ID</strong><span style="color: #ff0000">*</span><br />
                    <asp:TextBox ID="txt_Email" runat="server" CssClass="frmTxt" 
                        ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txt_Email" ErrorMessage="Enter Email ID" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2">Enter Email ID</asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txt_Email" ErrorMessage="Enter valid Email ID" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        Width="222px"></asp:RegularExpressionValidator>
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Address</strong><span style="color: #ff0000">*</span><br />
                    <asp:TextBox ID="Txt_address" runat="server" cssclass="frmTxt" 
                        ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="Req_Address" runat="server" 
                        ControlToValidate="txt_address" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter address " 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="209px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">City</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="Txt_city" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalpha(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="Req_city" runat="server" 
                        ControlToValidate="txt_city" CssClass="frmTblRowErr" ErrorMessage="Enter city" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="218px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">State </strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="Txt_state" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalpha(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="Reqarea" runat="server" 
                        ControlToValidate="Txt_state" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter area " 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="210px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <div class="frmTblRow">
                    <strong style="color:Red">Country</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="Txt_country" runat="server" CssClass="frmTxt" 
                        onkeypress="return onlyalpha(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="Txt_country" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter Country name" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="215px"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Pincode</strong><span style="color: #ff0000">*</span>
                    <br />
                    <asp:TextBox ID="txt_pincode" runat="server" CssClass="frmTxt" MaxLength="6" 
                        onkeypress="return onlynumber(event)" ValidationGroup="Reg2"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="Req_pin" runat="server" 
                        ControlToValidate="txt_pincode" CssClass="frmTblRowErr" 
                        ErrorMessage="Enter pincode" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationGroup="Reg2" Width="237px"></asp:RequiredFieldValidator>
                    <br />
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
                    <div style="font-size:11px;font-style:italic;display:block;height: 33px;" class="helptext">
                        &nbsp;Should be a 10 digit number</div>
                    <asp:RegularExpressionValidator ID="Regexp_mobile" runat="server" 
                        ControlToValidate="txt_Mobile" CssClass="frmTblRowErr" 
                        ErrorMessage="Invalid mobile No." Font-Names="Arial" 
                        style="color: #003366;font-size:12px;font-family:@Arial Unicode MS" 
                        ValidationExpression="^([7-9]{1})([0-9]{1})([0-9]{8})$" ValidationGroup="Reg2" 
                        Width="208px"></asp:RegularExpressionValidator>
                </div>
                <br />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="frmTblRow" style="text-align: center">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Btn_submit" runat="server" Class="btn btn-primary" 
                        onclick="Btn_submit_Click" Text="Submit" ValidationGroup="Reg2" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                </div>
            </td>
            
        </tr>
      </table>
   
         </div> 
    </div> 
</asp:Content>

