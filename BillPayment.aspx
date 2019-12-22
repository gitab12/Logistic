<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="BillPayment.aspx.cs" Inherits="BillPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
  <style type="text/css">
table.gridtable {
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:Black;
	/*border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;*/

     -webkit-border-radius: 8px;
    -moz-border-radius: 8px;
    overflow:hidden;
    border-radius: 10px;
    -pie-background: linear-gradient(#ece9d8, #E5ECD8);   
    box-shadow: #666 0px 2px 3px;
    behavior: url(Include/PIE.htc);
    overflow: hidden;

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
        .style2
       {
           width: 282px;
           height: 21px;
       }
       .style3
       {
           height: 21px;
       }


        .mapouterdiv {
    /*margin:5px;*/
    padding:0;
    width :750px;
    height :450px;
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
  
   
<link rel="stylesheet" type="text/css" media="all" href="jss/jsDatePick_ltr.min.css" />

<script type="text/javascript" src="jss/jquery.1.4.2.js"></script>
<script type="text/javascript" src="jss/jsDatePick.jquery.min.1.3.js"></script>

<script type="text/javascript">
    window.onload = function() {
        new JsDatePick({
            useMode: 2,
            target: "inputField",
            dateFormat: "%d-%M-%Y"

        });
    };
</script>
<SCRIPT TYPE="text/javascript">
<!--
    function popup(mylink, windowname) {
        if (!window.focus) return true;
        var href;
        if (typeof (mylink) == 'string')
            href = mylink;
        else
            href = mylink.href;
        window.open(href, windowname, 'width=900,height=1000,scrollbars=yes');
        return false;
    }
//-->
</SCRIPT>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
<%--
  <script language="javascript" type="text/javascript">
      function GetImageID(temp) {
          var ImageID = document.getElementById(temp).value;
          //alert(ImageID);
          document.getElementById("hdf_ImageID").value = ImageID;
          var x = document.getElementById("hdf_ImageID").value;

          CallBindWindow();
          return true;
      }

      function CallBindWindow() {
          __doPostBack('BindWindow', '');


      }
   
</script>--%>
    <br />
    <div style="margin-left:250px">
     <div class ="mapouterdiv" >
<table  cellpadding="0px" cellspacing="0px" align="center" width="695px">
        
        <tr>
            <td colspan="3" align="center">
                        &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;
                        </td>
                        
                      
  
        </tr>
        <tr><td align="center">
                                           
            &nbsp;</td></tr>
        <tr><td valign="top" colspan="2" align="left">
         <div class ="mapinnerdiv" >
                                            <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                         <center >   Bill Payment </center></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                             <tr>
                                                                 <td> Project Name :
                                                                    <asp:DropDownList ID="ddl_ProjectName" Width="150px" AutoPostBack ="true" runat="server" OnSelectedIndexChanged="ddl_ProjectName_SelectedIndexChanged"></asp:DropDownList>
                                                                </td>
                                                                <td> Project No :
                                                                     <asp:DropDownList ID="ddl_ProjectNo" Width="150px" AutoPostBack ="true"  runat="server" OnSelectedIndexChanged="ddl_ProjectNo_SelectedIndexChanged"></asp:DropDownList>
                                                                </td>
                                                                <td> Bill No :
                                                                    <asp:DropDownList ID="ddlBillNo" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddlBillNo_SelectedIndexChanged" >   </asp:DropDownList>
                                                                </td>
                                                                  <td class="style3">
                                                                    Transporter<br />
                                                                    <asp:TextBox ID="txt_Transporter" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                    
                                                                    </td>

                                                            </tr>

                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="lblConfirm" runat="server" Text="Cofirm No" Font-Bold="true"></asp:Label> 
                        &nbsp;<br />
                                                                    <asp:DropDownList ID="ddlCofirm" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddlCofirm_SelectedIndexChanged" 
                            >
                        </asp:DropDownList></td>
                                                                <td class="style3"  >
                                                                    BillNo 
                                                                    <asp:TextBox ID="txtbillno" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                                <td class="style3"   >
                                                                    <span >Billdate</span><br />  <asp:TextBox ID="inputField" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
</td>
                                                                <td class="style3">
                                                                    <span >BillValue<br />
                                                                    </span><asp:TextBox ID="txtbillvalue" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    From<br />
                                                                    <asp:TextBox ID="txtfrom" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    To<br />
                                                                    <asp:TextBox ID="txtto" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    Truck type <br />
                                                                    <asp:TextBox ID="txttrucktype" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    LR Number<br />
                                                                    <asp:TextBox ID="txtLRNo" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    Mode of Payment<br />
                                                                    <asp:DropDownList ID="ddlpaymentMode" runat="server" Width="150px" onselectedindexchanged="ddlCofirm_SelectedIndexChanged" 
                            >
                                                                        <asp:ListItem Value="0">Cheque</asp:ListItem>
                                                                        <asp:ListItem Value="1">RTGS</asp:ListItem>
                        </asp:DropDownList><br />
                                                                     </td>
                                                                <td class="style3">
                                                                    ChequeNumber<br />
                                                                    <asp:TextBox ID="txtchequeNo" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                   ChequeDate<br />
                                                                    <asp:TextBox ID="txtchequedate" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Amount<br />
                                                                    <asp:TextBox ID="txtamount" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                                        <tr>
                                                                <td class="style3">
                                                                    Remarks<br />
                                                                    <asp:TextBox ID="txtRemarks" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                                                                     <br />
                                                                     </td>
                                                                <td class="style3">
                                                                    BillImage<br />
                                                                      <a href="BillPreview.aspx" onClick="return popup(this, 'notes')"> 
 <asp:Image ID="BillImage" runat="server"  Width="150px" Height="60px" /></a>
                                                                     </td>
                                                               <td class="style3">
                                                                     
                                                                    <asp:LinkButton ID="LinkHistory" runat="server" onclick="LinkHistory_Click">View WorkFlow</asp:LinkButton>
                                                                   <asp:Label ID="lblBillID" runat="server" ForeColor="White"></asp:Label>

                                                                    <br />
                                                                     </td>
                                                                <td class="style3">
                                                                    <asp:Button ID="But_Submit" runat="server" Text="Submit" 
                                                                        onclick="But_Submit_Click" />
                                                                    <br />
                                                                     </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
               
    </table>
             </div> 
    </table>
         </div> 
        </div>
    <br /><br /><br />  <br /><br /><br />  <br /><br /><br /> <br /><br /><br />
</asp:Content>

