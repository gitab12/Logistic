<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceBillPayment.aspx.cs" Inherits="InvoiceBillPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <script type="text/javascript">

         // only numbers
         function onlynumber(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 48 || charCode > 57) && (charCode != 8))
                 return false;
             return true;
         }
         </script>

</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       
    <div> <center>
    <asp:Panel ID ="pnl_Header" runat ="server" valign="center" style="margin-right :50px;" BorderStyle="Ridge"  Width ="730px">
    <table ><tr>
        <td valign="top">
        <table class="auto-style1">
            <tr>
                <td><asp:Panel ID ="pnl_Address" runat ="server" BorderStyle="Groove" >
                    <asp:Image ID="img_Logo" runat="server" ImageUrl ="~/images/value-chain.png"  Height="45px" Width="162px" />
                    <br />
                    <asp:Label ID ="lbl_Companyname" runat ="server" Text ="AARMS VALUE CHAIN PRIVATE LIMITED" ></asp:Label>
                   <br /> #211,Temple Street,&nbsp;9th Main Road,<br /> BEML III Stage, &nbsp;Rajarajeswarinagar,<br />
                    &nbsp;Bangalore-560098.<br /> Contact No : 9845497950<br />
                    Email : <a href="mailto:g.jagan@aarmscmsolutions.com">g.jagan@aarmsvaluechain.com</a><br />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:DropDownList ID="ddl_BuyerorTo" runat="server" Height="25px" Width="135px">
                        <asp:ListItem>Buyer</asp:ListItem>
                        <asp:ListItem>To</asp:ListItem>
                    </asp:DropDownList>
                    <div id ="Div_Buyer"></div>
                   <%-- <asp:Label ID="lbl_Buyer" runat="server" Text="Label" Visible="false"></asp:Label>--%>
                    <br />
                    <asp:TextBox ID="txt_BuyerOrTodetails" runat="server" Height="82px" TextMode="MultiLine" Width="303px"></asp:TextBox>
                    
                </td>
            </tr>
        </table>
            </td>
        <td valign="top">
            <td valign="top"><asp:Panel ID ="Panel1" runat ="server" BorderStyle="Groove" >
        <table style="height: 212px; width: 369px" class="ex1" >
            <tr >
                <td class="auto-style4">

                    <asp:Label ID="lbl_BillNO" runat="server"></asp:Label>
                    <asp:TextBox ID ="txt_InvoiceID" runat ="server" Width ="40px" ></asp:TextBox><asp:ImageButton ID ="imgbtn_Search" runat ="server"  ImageUrl ="~/images/search icon2.jpg" Width ="30px" Height ="20px" OnClick="imgbtn_Search_Click" />
                    <br />
                    <hr />

                </td>
                <td class="auto-style4">

                    Dated :<asp:TextBox ID="txt_Dated" runat="server" Width="82px" ReadOnly ="true" ></asp:TextBox>

                <hr style="height: -12px" />

                </td>
            </tr>
            <tr>
                <td>

                    Domain :<br />
                    <asp:DropDownList ID="ddl_Domain" runat="server" Height="25px" Width="125px" AutoPostBack="True" OnSelectedIndexChanged="ddl_Domain_SelectedIndexChanged" >
                          <asp:ListItem>SCMBizconnect1</asp:ListItem>
                        <asp:ListItem>SCMBizconnect</asp:ListItem>
                        <asp:ListItem>SCMJunction</asp:ListItem>
                        <asp:ListItem>AaumConnect</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <div id ="Div_Domain"></div>
<%--<asp:Label ID="lbl_Domain" runat="server" Text="Label" Visible ="false" ></asp:Label>--%>
                    <br />
                <hr style="height: -12px" />

                </td>
                <td>

                    Other References :<br />
                    <asp:TextBox ID="txt_OtherRef" runat="server"></asp:TextBox>

                <hr style="height: -12px" />

                </td>
            </tr>
            <tr>
                <td colspan ="2" valign="top" >
                    Remarks :<br />
                    <asp:TextBox ID="txt_Remarks" runat="server" TextMode="MultiLine" Height ="30px" Width="260px"></asp:TextBox>

                </td>
              
            </tr>
            </table>
                </asp:Panel> 
                
            </td>
        </tr>
        </table>
                <hr style="width: 730px; margin-left: 0px" />
          <center> <b style="font-family: Arial; font-size: medium; font-weight: bold; font-style: normal; color: #FF0000">Invoice Bill Payment</b>
              <br />
<asp:Label id ="lbl_Msg" runat="server" Font-Bold="true" ForeColor="Green" visible="false"></asp:Label>
                           <br />
                           <br /></center>
       <%-- <table style="height: 440px"  class ="tableline"  >--%>
             <table  border="1"  rules="cols" frame="box" align="center" style="width: 380px; height: 197px" >
            <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
               <td>
                   Payment Date 
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:TextBox ID="txt_PaymentDate" runat="server"></asp:TextBox>
                       <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px" />   
                             <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                    PopupButtonID="imgdate1" TargetControlID="txt_PaymentDate"></ajaxtoolkit:calendarextender>
               </td>
            </tr>
            <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
                 <td>
                   Recieved From 
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:TextBox ID="txt_RecievedFrom" runat="server"></asp:TextBox>
               </td>
                
            </tr>
            <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
                 <td>
                   Payment Mode 
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:DropDownList ID="ddl_PaymentMode" runat="server" Width="142px">
                         <asp:ListItem>Cheque</asp:ListItem>
                         <asp:ListItem>RTGS</asp:ListItem>
                         <asp:ListItem>DD</asp:ListItem>
                     </asp:DropDownList>
               </td>
            </tr>
            <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
                <td>
                   Bill Amount 
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:TextBox ID="txt_BillAmount" Enabled ="false" runat="server"></asp:TextBox>
               </td>
            </tr>
            <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
               <td>
                   Amount Paid 
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:TextBox ID="txt_AmountPaid" runat="server" Enabled ="false"  Text ="0"></asp:TextBox>
               </td>
            </tr>
                 <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
                      <td>
                   Balance Amount 
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:TextBox ID="txt_BalanceAmount" Enabled ="false" runat="server"></asp:TextBox>
               </td>
                 </tr>

                 <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
                      <td>
                   Amount Payment
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:TextBox ID="txt_AmountPayment" MaxLength ="7" onkeypress="return onlynumber(event)" runat="server"></asp:TextBox>
               </td>
                 </tr>


                 <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
                      <td>
                   Remarks
               </td>
                 <td>
                     :
               </td>
                 <td>
                     <asp:TextBox ID="txt_InvoiceRemarks" TextMode ="MultiLine" Height ="100px" Width ="140px"  runat="server"></asp:TextBox>
               </td>
                 </tr>

                 <tr>
                     <td colspan ="3" align="center">
                         <br />
                         <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick ="btn_Submit_Click"   />
                         <br />
        <br />
                     </td>
                 </tr>

        </table>
           
        <br />
        <br />
        </asp:Panel>
        </center>
    </div>
            
    </form>
</body>
</html>
