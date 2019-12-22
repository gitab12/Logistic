<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="EditProduct"  %>
<%@ Register Src="~/UserControl/NavigationControlHome.ascx" TagPrefix="Uc4" TagName="DashboardMenuBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br /><br />
    <Uc4:DashboardMenuBar runat="server" id="DashboardMenuBar" />
    <br /><br />
  <div style="margin-left:350px">
  <table width="70%" >
       <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Product Type</strong><br />
                <asp:DropDownList
                        ID="DDLproducttype" runat="server" CssClass="frmTxt" Height="25px" 
                    Width="212px" AutoPostBack="True" 
                    onselectedindexchanged="DDLproducttype_SelectedIndexChanged">
                </asp:DropDownList>
                </div>
                </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong>Product Category<br />
                    </strong>
                    <asp:DropDownList
                        ID="DDLproductcategory" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
          <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Product Name</strong><span style="color: #ff0000">*</span><br />
                <asp:TextBox ID="Txt_productname" runat="server" CssClass="frmTxt" ValidationGroup="reg"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="Req_company" runat="server" ControlToValidate="Txt_productname"
                        CssClass="frmTblRowErr" ErrorMessage="Enter Product name" ValidationGroup="Reg2"
                        Width="132px"></asp:RequiredFieldValidator>
                </div>
                </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                     <strong>Product Description</strong>
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
                <strong>Packing Method<br />
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
                <strong>Stock Keeping UnitID(SKU)<br />
						 <asp:TextBox ID="Txt_sku" runat="server" cssclass="frmTxt" ></asp:TextBox></strong></div>
            </td>
       </tr>
         <tr><td colspan="2" ><hr /></td></tr>
       <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Weight<br />
                </strong>
                    <asp:TextBox ID="txt_weight" runat="server" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong>Weight Unit</strong><br/><asp:DropDownList
                        ID="DDLWeightUnit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
      <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Length<br />
                </strong>
                    <asp:TextBox ID="txt_length" runat="server" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong>Length Unit</strong><br/><asp:DropDownList
                        ID="DDLLengthUnit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
      <tr>
          <td style="width: 100px">
           <div class="frmTblRow">
              <strong>Width<br />
              </strong>
              <asp:TextBox ID="Txt_width" runat="server" AutoCompleteType="none" CssClass="frmTxt"
                  ValidationGroup="reg"></asp:TextBox>
                  </div>
          </td>
          <td style="width: 100px">
           <div class="frmTblRow">
              <strong>Width Unit</strong><br/>
              <asp:DropDownList
                        ID="DDLwidthunit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
              </asp:DropDownList>
              </div>
              </td>
      </tr>
         <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Height<br />
                </strong>
                    <asp:TextBox ID="txt_height" runat="server" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong>Height Unit</strong><br/><asp:DropDownList
                        ID="DDLHeightUnit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
         <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Volume<br />
                </strong>
                    <asp:TextBox ID="txt_volume" runat="server" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong>Volume Unit</strong><br/><asp:DropDownList
                        ID="DDlvolumeunit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
         <tr>
         
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Packing Space</strong><br />
                    <asp:DropDownList
                        ID="DDLpckngsp" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                        <asp:ListItem Value="SELECT">SELECT</asp:ListItem>
                        <asp:ListItem Value="1">TRUE</asp:ListItem>
                        <asp:ListItem Value="0">FALSE</asp:ListItem>
                    </asp:DropDownList></div>
                </td>
                <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Transportation cost per unit<br />
						 <asp:TextBox ID="txt_transcostperunit" runat="server" cssclass="frmTxt" ></asp:TextBox></strong></div>
            </td>
                
            
           
        </tr>
        
       <tr><td colspan="2"><hr /></td></tr>
       
            
        <tr>
            <td colspan="2">
              
                <div   class="frmTblRow" style="text-align: center">
                    <asp:Button ID="Btn_submit" runat="server" Class="btn btn-primary"  Text="Update" 
                        ValidationGroup="Reg2" onclick="Btn_submit_Click" />
                    <br />
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="12pt" ForeColor="Red" Width="251px"></asp:Label>
                    </div>
            </td>
        </tr>
    </table>
       <br /><br /><br /><br /><br />
    </div>
</asp:Content>

