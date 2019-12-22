<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="CollectionNote.aspx.cs" Inherits="CollectionNote" %>
<%@ Register Src ="~/UserControl/ESignature.ascx" TagName="ESign" TagPrefix ="UES" %>
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
          <script language="javascript" type="text/javascript">
        function callPrint(elementId)
    {
       var prtContent = document.getElementById(elementId);                
       var WinPrint = window.open('','', 'left=0,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
       var docColor="Black";
       var strInnerHTML=prtContent.innerHTML;
       var strModifiedInnerHTMl=strInnerHTML.replace(/white/g,docColor);
       WinPrint.document.write(strModifiedInnerHTMl);
       WinPrint.document.close();
       WinPrint.focus();
       WinPrint.print();
       WinPrint.close();
   }

   //Only Numbers
   function onlynumber(evt) {
       var charCode = (evt.which) ? evt.which : event.keyCode
       if ((charCode < 48 || charCode > 57) && (charCode != 8))
           return false;
       return true;
   }
      </script>

    <script src="http://code.jquery.com/jquery-latest.js"></script>
<script type='text/javascript'>
    $(function () {
        // To disable f5
        $(document).bind("keydown", disableF5);
    });

    //Function to handle disabling F5
    function disableF5(e) {
        if ((e.which || e.keyCode) == 116)
            //alert("shyam");
            //window.open("http://viralpatel.net/blogs/", "mywindow", "status=1,toolbar=0");
            e.preventDefault();
    };
</script>

</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
 <asp:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="true">
            </asp:ScriptManager>


<div class="row text-center clearfix">
							<%--	<div class="col-sm-8 col-sm-offset-3">	--%>
<table  cellpadding="0px" cellspacing="0px" align="left" width="695px" id="TblCollectionNote" style="margin-left:150px">
        
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
                                           
           <asp:RadioButton ID="Generate" runat="server" Checked="True" 
                    Text="Generate Collection Note" Font-Names="Arial" Font-Size="10pt" 
                    ValidationGroup="b" GroupName="s"  AutoPostBack="true" oncheckedchanged="Generate_CheckedChanged"  />
                <asp:RadioButton ID="NeedApproval" runat="server" Text="Need Approval" 
                    Font-Names="Arial" Font-Size="10pt" ValidationGroup="b" GroupName="s" AutoPostBack="true"
                    oncheckedchanged="NeedApproval_CheckedChanged"   />
                     &nbsp;
                    <asp:RadioButton ID="rdb_Amendment" runat="server" AutoPostBack="true" Font-Names="Arial" Font-Size="10pt" GroupName="s" oncheckedchanged="rdb_Amendment_CheckedChanged" Text="Amendment" ValidationGroup="b" />
                    
                    &nbsp;
            <asp:RadioButton ID="rdb_AlterTransporter" runat="server" AutoPostBack="true" Font-Names="Arial" Font-Size="10pt" GroupName="s" oncheckedchanged="rdb_AlterTransporter_CheckedChanged" Text="Alternate Transporter" ValidationGroup="b" />
                    &nbsp;&nbsp;
                   <asp:RadioButton ID="rdb_SPLRC" runat="server" AutoPostBack="true" Font-Names="Arial" Font-Size="10pt" GroupName="s" oncheckedchanged="rdb_SPLRC_CheckedChanged" Text="SPL RC" ValidationGroup="b" /> 
                    </td></tr>
        <tr><td valign="top" colspan="2" align="left">
         <div class ="mapouterdiv" >
       <div class ="mapinnerdiv" >

                                            <table align="left"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
          <tr>
                                                    <td class="td_bgcolor" align="left" style="color:Red" >
                                                        CollectionNote Date  
                                                        <asp:TextBox ID="txtCNdate" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
&nbsp;CollectionNote No  
                                                        <asp:TextBox ID="txtCNNumber" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" Width="77px" ReadOnly="true"></asp:TextBox>
                                                        <asp:DropDownList ID="ddl_CNNo" runat="server" AutoPostBack="True"  Width="80px" OnSelectedIndexChanged="ddl_CNNo_SelectedIndexChanged" Visible ="false" >
                                                        </asp:DropDownList>
                                                          Auto No<asp:TextBox ID="txtautonumber" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                         &nbsp;<asp:DropDownList ID="ddl_CnGeneratedNo" runat="server" AutoPostBack="True" onselectedindexchanged="ddl_CnGeneratedNo_SelectedIndexChanged" Width="150px">
                                                        </asp:DropDownList>
                                                                                
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                        <asp:Label ID="lblConfirm" runat="server" Text="Project No" Font-Bold="true"></asp:Label> 
                        &nbsp;<asp:Label ID="lbl_ProjectNo" runat="server" Font-Bold="True"></asp:Label>
                        <br />
                                                                    <asp:DropDownList ID="ddlProjectNo" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddlProjectNo_SelectedIndexChanged" 
                            >
                        </asp:DropDownList></td>
                                                                <td class="style3"  >
                                                                    WBS No   <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                                                                    <asp:Label ID="lbl_WbsNo" runat="server" Font-Bold="True"></asp:Label>
                                                                                            &nbsp; <asp:DropDownList ID="DDLWBSno" 
                                                                        runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="DDLWBSno_SelectedIndexChanged" 
                            >
                        </asp:DropDownList> 
                                                                  </td>
                                                                <td class="style3"   >
                                                                    Serial No
                                                                    &nbsp;
                                                                    <asp:Label ID="lbl_SerialNo" runat="server" Font-Bold="True"></asp:Label>
                                                                    <br />
                                                                    <asp:DropDownList ID="DDLserialno" 
                                                                        runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="DDLserialno_SelectedIndexChanged" 
                            >
                        </asp:DropDownList> 
                                                                    
</td>
                                                                <td class="style3">
                                                                    <span >Vehicle Req. Date<br />
                                                                    <asp:TextBox ID="txtdate" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    </span></td>

                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Project Name<br />
                                                                    <asp:TextBox ID="txtproject" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Description<br />
                                                                    <asp:TextBox ID="txtDescription" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                     
                                                                     
                                                                     
                                                                     </td>
                                                               <td class="style3">
                                                                    Truck type <asp:LinkButton ID="LinkEdit" runat="server" onclick="LinkEdit_Click" Visible="true" >Edit</asp:LinkButton>
                                                                    <br />
                                                                    <asp:TextBox ID="txttrucktype" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" ></asp:TextBox>
                                                                     <br />
                                                                       <asp:DropDownList ID="DDLTruckType" 
                                                                        runat="server" Width="150px" 
                            AutoPostBack="True" o  Visible="false" onselectedindexchanged="DDLTruckType_SelectedIndexChanged"      >
                        </asp:DropDownList>
                                                                     </td>
                                                                <td class="style3">
                                                                    Transit Days<br />
                                                                    <asp:TextBox ID="txttransit" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                                                      
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                From<br />
                                                                    <asp:TextBox ID="txtFrom" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"  ></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                To<br />
                                                                    <asp:TextBox ID="txtTo" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"  ></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                             Trucks Contracted :
                                                                   <asp:Label ID="LblTruckscontructed" runat="server" ForeColor="Black"  ></asp:Label>
                                                                     <br />
                                                                  Trucks Assigned :
                                                                   <asp:Label ID="LblTruckAssigned" runat="server" ForeColor="Black"  ></asp:Label>
                                                                     <br />
                                                                  Trucks Remaining :
                                                                  <asp:Label ID="lblTrucksRemainder" runat="server" ForeColor="Black"  ></asp:Label>
                                                                     </td>
                                                                <td class="style3">
                                                                Trucks Required<br />
                                                                    <asp:TextBox ID="txtTruckPlanned" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"  ></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    Length in feet<br />
                                                                    <asp:TextBox ID="txtlength" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                    <br />
                                                                     </td>
                                                                <td class="style3">
                                                                    width in feet<br />
                                                                    <asp:TextBox ID="txtwidth" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                   Height in feet<br />
                                                                    <asp:TextBox ID="txtheight" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    TotalWeight in Tons<br />
                                                                    <asp:TextBox ID="txtweight" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    Consignor<br />
                                                                    <asp:TextBox ID="txtbuyer" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                        Consignor Contact Person<br />
                                                                    <asp:TextBox ID="txtcontactperson" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                        Consignor Contact Number<br />
                                                                    <asp:TextBox ID="txtcontactnumber" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                   Project manager name<br />
                                                                    <asp:TextBox ID="txt_ManagerName" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    <br />
                                                                    Project manager no<br />
                                                                    <asp:TextBox ID="txt_PmContactno" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"  onkeypress="return onlynumber(event)" ></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                               Buyer name<br />
                                                                   <asp:TextBox ID="txt_Buyername" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                   <br />
                                                                   Buyer contact no<br />
                                                                   <asp:TextBox ID="txt_Buyercontactno" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" ></asp:TextBox>
                                                                   <br />
                                                                   Site incharge name<br />
                                                                   <asp:TextBox ID="txt_Siteinchargename" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                   <br />
                                                                   Site incharge contact no<br />
                                                                   <asp:TextBox ID="txt_Inchargecontactno" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" ></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    Transporter<br />
                                                                    <asp:TextBox ID="txtTransporter" runat="server" Enabled="false"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" ReadOnly="true"></asp:TextBox>
                                                                    <br />
                                                                    <%--<asp:Label ID="lbl_Email" runat="server" Text="Email"></asp:Label>--%>
                                                                    <asp:DropDownList ID="ddl_Transporter" runat="server" Width ="150px" AutoPostBack ="true"  OnSelectedIndexChanged="ddl_Transporter_SelectedIndexChanged"></asp:DropDownList> 
                                                                    <br /><asp:Label ID="lbl_RcNo" runat="server"  Text ="Rc No :"></asp:Label><br />
                                                                    <asp:TextBox ID="txt_RcNo" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="97px"></asp:TextBox>
                                                                    
                                                                    <br /><asp:Label ID="lbl_Rate" runat="server" Font-Bold="False" Visible ="false" Text ="Rate :"  ></asp:Label>
                                                                    <br />
                                                                    <asp:TextBox ID="txt_Rate" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="97px" Visible ="false"  ></asp:TextBox>
                                                                    <br />
                                                                    <asp:Label ID="lbl_TransEmail" runat="server" Font-Bold="False" Visible ="false" Text ="Email :"  ></asp:Label><br />
                                                                    <asp:TextBox ID="txt_TransporterEmail" Visible ="false" Enabled = false runat="server"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                                        <tr>
                                                                <td class="style3">
                                                                    Remarks<br />
                                                                    <asp:TextBox ID="txtRemarks" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                                                                     <br />
                                                                     </td>
                                                                <td class="style3" colspan="2">
                                                                    Any attachment<br />
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="False" />
                                                                    <br />
                                                                    <asp:LinkButton ID="link_preview" runat="server" onclick="link_preview_Click">Preview</asp:LinkButton>
                                                                     
                                                                   <asp:Label ID="lblBillID" runat="server" ForeColor="White"></asp:Label>

                                                                    <br />
                                                                     </td>
                                                                <td class="style3">
                                                                    <asp:Button ID="But_NApproval" runat="server" Text="Need Approval" 
                                                                        onclick="But_NApproval_Click" Enabled="false"  /><br />
                                                                    <asp:Button ID="But_Submit" runat="server" Text="Submit" Width="115px"
                                                                        onclick="But_Submit_Click" />
                                                                    <br />
                                                                    <asp:Button ID="btn_Amendment" runat="server" onclick="btn_Amendment_Click" Text="Amendment" Enabled="false" Width="115px" />
                                                                     </td>
                                                            </tr>
                                                            
                                                                     <tr>
                                                                <td class="style3">
                                                                   Justification for approval<br />
                    <asp:CheckBoxList ID="Chkjustification" runat="server" Height="44px">
                    <asp:ListItem Value="0" Text="Change in Type of vehicle"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Change in Location"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Change in Dimension"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Extra vehicle required"></asp:ListItem>
                    
                    </asp:CheckBoxList>
                                                                   
                                                                   <br />
                                                                    <asp:TextBox ID="txtjustification" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox></td>
                                                                <asp:TextBox ID="txtAgreedPrice" runat="server"  BorderColor="White" ForeColor="White"  
                                                                        BorderStyle="None" BorderWidth="0px"></asp:TextBox>
                                                                <td class="style3" colspan="2">
                                                                
                                                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                                                        <asp:Label ID="Lblmsg" runat="server" 
                                                                            Text="Do you want to add collection under same collectionnote number" 
                                                                            Font-Names="Arial" Font-Size="12pt" ForeColor="Red"></asp:Label>
                                                                        <br />
                                                                        <asp:Button ID="ButYes" runat="server" Text="Yes" onclick="ButYes_Click" />
                                                                        <asp:Button ID="ButNo" runat="server" Text="No" onclick="ButNo_Click" />
                                                                    </asp:Panel>
                                                                     </td>
                                                                <td class="style3">
                                                                   <UES:ESign ID="Esign" runat="server" />
                                                                            </td>
                                                            </tr>
                                                            
                                                            
                                                        </table>
                                                        </div> </div> 

                                                    </td>
                                                </tr>
                                                
                                                
               
    </table>
      <center><asp:Button ID="Print" runat="server"  OnClientClick ="callPrint('TblCollectionNote')"
    Text="Print CollectionNote" Width="156px" /></center>
    </table>
                                  <%--  </div>--%>
    </div>
     </ContentTemplate>
      <Triggers>

    <asp:PostBackTrigger ControlID = "Esign" />
        <asp:PostBackTrigger ControlID = "But_NApproval" />
        <asp:PostBackTrigger ControlID = "But_Submit" />
        <asp:PostBackTrigger ControlID = "btn_Amendment" />


</Triggers>
    </asp:UpdatePanel>

</asp:Content>

