<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="ProductCreation.aspx.cs" Inherits="ProductCreation"  %>

<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

    <style type="text/css">

        
        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :550px;
    height :750px;
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
    height :740px;
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

 <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="12pt" ForeColor="Red" Width="251px" Visible="false"></asp:Label>
<table width="70%" >
      <br />
       <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Product Type</strong><br />
                <asp:DropDownList
                        ID="DDLproducttype" runat="server" CssClass="frmTxt" Height="25px" 
                    Width="212px" onselectedindexchanged="DDLproducttype_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </div>
                </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Product Category<br />
                    </strong>
                    <asp:DropDownList
                        ID="DDLproductcategory" runat="server" CssClass="frmTxt" Height="25px" 
                        Width="212px" 
                        onselectedindexchanged="DDLproductcategory_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
          <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Product Name</strong><span style="color: #ff0000">*</span><br />
                <asp:TextBox ID="Txt_productname" runat="server" CssClass="frmTxt" ValidationGroup="reg"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="Req_company" runat="server" ControlToValidate="Txt_productname"
                        CssClass="frmTblRowErr" ErrorMessage="Enter Product name" ValidationGroup="Reg2"
                        Width="132px"></asp:RequiredFieldValidator>
                </div>
                </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                     <strong style="color:Red">Product Description</strong>
                     <asp:TextBox ID="txt_productDescription" runat="server" AutoCompleteType="none" cssclass="frmTxt" ValidationGroup="Reg2"></asp:TextBox>
                </div>
            </td>
        </tr>
     
        
       
      <%--
      <tr>
          <td style="width: 100px">
          <div class="frmTblRow">
              <strong>Measurement Type</strong><br/><asp:DropDownList
                        ID="DDLmeasurementtype" runat="server" CssClass="frmTxt" Height="25px" Width="212px" AutoPostBack="True">
                </asp:DropDownList>
                </div>
                </td>
                
          <td style="width: 100px">
          <div class="frmTblRow">
              <strong>Unit of Measurement<br />
              </strong>
              <asp:DropDownList
                        ID="DDLunit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
              </asp:DropDownList>
              </div>
          </td>
      </tr>--%>
      <tr>
     
      <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Packing Method<br />
                </strong>
              <asp:DropDownList
                        ID="DDLpackingType" runat="server" CssClass="frmTxt" Height="25px" 
                    Width="212px" AutoPostBack="True" 
                    onselectedindexchanged="DDLpackingType_SelectedIndexChanged">
              </asp:DropDownList>
              </div>
            </td>
            
            
       
       <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Stock Keeping UnitID(SKU)<br />
						 <asp:TextBox ID="Txt_sku" runat="server" onkeypress="return onlynumber(event)" cssclass="frmTxt" ></asp:TextBox></strong></div>
            </td>
       </tr>
         <tr><td colspan="2" ><hr /></td></tr>
       <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Weight<br />
                </strong>
                    <asp:TextBox ID="txt_weight" runat="server" onkeypress="return onlynumberwithDecimals(event)"  AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong style="color:Red">Weight Unit</strong><br/><asp:DropDownList
                        ID="DDLWeightUnit" runat="server" CssClass="frmTxt"  Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
      <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Length<br />
                </strong>
                    <asp:TextBox ID="txt_length" runat="server" onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong style="color:Red">Length Unit</strong><br/><asp:DropDownList
                        ID="DDLLengthUnit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
      <tr>
          <td style="width: 100px">
           <div class="frmTblRow">
              <strong style="color:Red">Width<br />
              </strong>
              <asp:TextBox ID="Txt_width" runat="server"  onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt"
                  ValidationGroup="reg"></asp:TextBox>
                  </div>
          </td>
          <td style="width: 100px">
           <div class="frmTblRow">
              <strong style="color:Red">Width Unit</strong><br/>
              <asp:DropDownList
                        ID="DDLwidthunit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
              </asp:DropDownList>
              </div>
              </td>
      </tr>
         <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Height<br />
                </strong>
                    <asp:TextBox ID="txt_height" runat="server" onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong style="color:Red">Height Unit</strong><br/><asp:DropDownList
                        ID="DDLHeightUnit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
         <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Volume<br />
                </strong>
                    <asp:TextBox ID="txt_volume" runat="server" onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong style="color:Red">Volume Unit</strong><br/><asp:DropDownList
                        ID="DDlvolumeunit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Quantity<br />
                </strong>
                    <asp:TextBox ID="txt_quantity" runat="server" onkeypress="return onlynumber(event)" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong style="color:Red">Quantity Unit</strong><br/><asp:DropDownList
                        ID="DDLQuantityUnit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
         <tr>
         
          <td style="width: 100px">
                <div class="frmTblRow">
                    <strong style="color:Red">Include Package Space<br />
                    </strong>
                    <asp:DropDownList
                        ID="DDLpckngsp" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                        <asp:ListItem Value="SELECT">SELECT</asp:ListItem>
                        <asp:ListItem Value="1">YES</asp:ListItem>
                        <asp:ListItem Value="0">NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
                <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Transportation cost per unit<br />
						 <asp:TextBox ID="txt_transcostperunit" runat="server" onkeypress="return onlynumber(event)" cssclass="frmTxt" ></asp:TextBox></strong></div>
            </td>
                
            
           
        </tr>
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong style="color:Red">Aarm SCM Commission<br />
                </strong>
                    <asp:TextBox ID="txt_comm" runat="server" AutoCompleteType="none"  CssClass="frmTxt" 
                        ValidationGroup="reg" onkeypress="return onlynumber(event)"></asp:TextBox>
                    
                </div>
            </td>
           </tr>
        
       <tr><td colspan="2"><hr /></td></tr>
       
            
        <tr>
            <td colspan="2">
              
                <div   class="frmTblRow" style="text-align: center">
                    <asp:Button ID="Btn_submit" runat="server" class="btn  btn-primary"  Text="Submit" 
                        ValidationGroup="Reg2" onclick="Btn_submit_Click"  />
                    <br />
                    
                    </div>
            </td>
        </tr>
    </table>
                </div> 
        </div> 
</div>
</asp:Content>

