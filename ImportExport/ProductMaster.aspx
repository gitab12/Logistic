<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ImportExportMaster.master" AutoEventWireup="true" CodeFile="ProductMaster.aspx.cs" Inherits="ImportExport_ProductMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>

    <style type="text/css">



         .design {
             background: #ADD8E6;
             padding: 25px;
             border: 2px solid #fff;
             box-shadow: 0px -4px 5px rgba(0,0,0,0.3);
             color: #000;          
             padding-bottom: 15px;
             min-width: 400px;
             min-height: 200px;
             max-height: 550px;
             max-width: 900px;
           
        }
      

        .txtboxcss
        {
            border-bottom-right-radius: 8em;
            border-top-right-radius: 20px;
            border-bottom-left-radius: 20px;
            border-bottom-right-radius: 20px;
            border: 1px solid gray;
 padding: 1px;
 /*font-size: x-small;*/
     font-family: Tahoma;
     background-color: #ffffff;
 /*font-weight: 700;*/

        }
        .auto-style2 {
            height: 41px;
        }
        .auto-style4 {
            height: 59px;
        }


         .Panel legend
{
color:Maroon;
 font-weight:bold; 
 font-size :15px;
}

         .promotion_btn {
        -moz-box-shadow: inset 0px 1px 0px 0px #efdcfb;
        -webkit-box-shadow: inset 0px 1px 0px 0px #efdcfb;
        box-shadow: inset 0px 1px 0px 0px #efdcfb;
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #FFFFF), color-stop(1, #BCC6CC));
        background: -moz-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: -webkit-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: -o-linear-gradient(top,#FFFFF 5%, #BCC6CC 100%);
        background: -ms-linear-gradient(top, #FFFFF 5%, #BCC6CC 100%);
        background: linear-gradient(to bottom, #FFFFF 5%, #BCC6CC 100%);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFF', endColorstr='#BCC6CC',GradientType=0);
        background-color: #fff;
        -moz-border-radius: 10px;
        -webkit-border-radius: 10px;
        border-radius: 10px;
        border: 1px solid #c584f3;
        display: inline-block;
        cursor: pointer;
        color: black;
        font-family: arial;
        font-size: 15px;
        font-weight: bold;
        padding: 7px 25px;
        text-decoration: none;
        text-shadow: 0px 1px 0px #9752cc;
    }
    .promotion_btn:hover {
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #BCC6CC), color-stop(1, #FFFFF));
        background: -moz-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -webkit-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -o-linear-gradient(top, #FFFFF 5%, #FFFFF 100%);
        background: -ms-linear-gradient(top,#FFFFF 5%, #FFFFF 100%);
        background: linear-gradient(to bottom, #FFFFF 5%, #FFFFF 100%);
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FFFFF', endColorstr='#FFFFF',GradientType=0);
        background-color: #BCC6CC;
    }
    .promotion_btn:active {
        position: relative;
        top: 1px;
    }

        
        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :550px;
    height :850px;
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
    height :840px;
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
    <br />
    <br />
    <div class ="mapouterdiv" >
          <div class ="mapinnerdiv" >

 <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="12pt" ForeColor="Red" Width="251px" Visible="false"></asp:Label>
<table width="70%" >
       <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Product Type</strong><br />
                <asp:DropDownList
                        ID="DDLproducttype" runat="server" CssClass="frmTxt" Height="25px" 
                    Width="212px" onselectedindexchanged="DDLproducttype_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </div>
                </td>
            <td style="width: 100px">
                <div class="frmTblRow">
                    <strong>Product Category<br />
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
						 <asp:TextBox ID="Txt_sku" runat="server" onkeypress="return onlynumber(event)" cssclass="frmTxt" ></asp:TextBox></strong></div>
            </td>
       </tr>
         <tr><td colspan="2" ><hr /></td></tr>
       <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Weight<br />
                </strong>
                    <asp:TextBox ID="txt_weight" runat="server" onkeypress="return onlynumberwithDecimals(event)"  AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong>Weight Unit</strong><br/><asp:DropDownList
                        ID="DDLWeightUnit" runat="server" CssClass="frmTxt"  Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
      <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Length<br />
                </strong>
                    <asp:TextBox ID="txt_length" runat="server" onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt" 
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
              <asp:TextBox ID="Txt_width" runat="server"  onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt"
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
                    <asp:TextBox ID="txt_height" runat="server" onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt" 
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
                    <asp:TextBox ID="txt_volume" runat="server" onkeypress="return onlynumberwithDecimals(event)" AutoCompleteType="none" CssClass="frmTxt" 
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
                <strong>Quantity<br />
                </strong>
                    <asp:TextBox ID="txt_quantity" runat="server" onkeypress="return onlynumber(event)" AutoCompleteType="none" CssClass="frmTxt" 
                        ValidationGroup="reg"></asp:TextBox>
                    
                </div>
            </td>
            <td style="width: 100px">
            <div class="frmTblRow">
                           
                <strong>Quantity Unit</strong><br/><asp:DropDownList
                        ID="DDLQuantityUnit" runat="server" CssClass="frmTxt" Height="25px" Width="212px">
                </asp:DropDownList></div>
            </td>
        </tr>
         <tr>
         
          <td style="width: 100px">
                <div class="frmTblRow">
                    <strong>Include Package Space<br />
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
                <strong>Transportation cost per unit<br />
						 <asp:TextBox ID="txt_transcostperunit" runat="server" onkeypress="return onlynumber(event)" cssclass="frmTxt" ></asp:TextBox></strong></div>
            </td>
                
            
           
        </tr>
        <tr>
            <td style="width: 100px">
            <div class="frmTblRow">
                <strong>Aarm SCM Commission<br />
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
                    <asp:Button ID="Btn_submit" runat="server" class="promotion_btn" Text="Submit" 
                        ValidationGroup="Reg2" onclick="Btn_submit_Click" />
                    <br />
                    
                    </div>
            </td>
        </tr>
    </table>
                </div> 
        </div> 


</asp:Content>

