<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" EnableEventValidation="false"  Inherits="Invoice" %>
<%@ Register Assembly ="AjaxControlToolkit" Namespace ="AjaxControlToolkit" TagPrefix ="CC1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
       
          @media print {
.header, .hide { visibility: hidden }
}

             .modalBackground

{

  background-color:#CCCCFF;

  filter:alpha(opacity=40);

  opacity:0.5;

}

.ModalWindow

{

  border: solid1px#c0c0c0;

  background:#f0f0f0;

  padding: 0px10px10px10px;

  position:absolute;

  top:-1000px;

}


    </style>
        <script type="text/javascript">

            function callPrint(elementId) {
                var RowCount = '<%=Tblcount%>';

                var domain = document.getElementById('<%=ddl_Domain.ClientID%>');
                var domainvalue = domain.options[domain.selectedIndex].text;
                document.getElementById('Div_Domain').innerHTML = domainvalue;

                document.getElementById('<%=ddl_Domain.ClientID%>').style.display = 'none';

                //document.getElementById('<%=ddl_BuyerorTo.ClientID%>').style.display = 'none';
                var domain1 = document.getElementById('<%=ddl_BuyerorTo.ClientID%>');
                var domainvalue1 = domain1.options[domain1.selectedIndex].text;
                document.getElementById('Div_Buyer').innerHTML = domainvalue1;
                document.getElementById('<%=ddl_BuyerorTo.ClientID%>').style.display = 'none';
                
                var particulars = document.getElementById('<%=ddl_particulars.ClientID%>');
                var particularsvalue = particulars.options[particulars.selectedIndex].text;
                document.getElementById('Div_Particulars').innerHTML = particularsvalue;
                document.getElementById('<%=ddl_particulars.ClientID%>').style.display = 'none';

                var Quantity = document.getElementById('<%=ddl_QuantityorNooftrucks.ClientID%>');
                var Quantityvalue = Quantity.options[Quantity.selectedIndex].text;
                document.getElementById('Div_Quantity').innerHTML = Quantityvalue;
                document.getElementById('<%=ddl_QuantityorNooftrucks.ClientID%>').style.display = 'none';
                
                if (RowCount == "4") {
                   
                    var prtContent = document.getElementById(elementId);
                    var WinPrint = window.open('', '', 'left=1,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
                    document.getElementById('<%=txt_Amount2.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Amount1.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Amount3.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Amount4.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Rate1.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Rate2.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Rate3.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Rate4.ClientID%>').style.border = 0;
                    //document.getElementById('<%=ddl_QuantityorNooftrucks.ClientID%>').style.border = 0;
                    //document.getElementById('<%=ddl_BuyerorTo.ClientID%>').style.border = 0;
                    //document.getElementById('<%=ddl_Domain.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Quantity1.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Quantity2.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Quantity3.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Quantity4.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Desc1.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Desc2.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Desc3.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Desc4.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Dated.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_OtherRef.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Remarks.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_InvoiceID.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_AmountInwords.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_BuyerOrTodetails.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_GrandTotal.ClientID%>').style.border = 0;
                    document.getElementById('<%=imgbtn_Search.ClientID%>').style.display = 'none';
                    document.getElementById('<%=txt_Tax12per.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Tax2per.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Tax1per.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_12percent.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_2percent.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_1percent.ClientID%>').style.border = 0;
                    document.getElementById('<%=txt_Total.ClientID%>').style.border = 0;


                    if (document.getElementById('<%=txt_Amount2.ClientID%>').value == 0) {
                        document.getElementById('<%=txt_Amount2.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Rate2.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Quantity2.ClientID%>').style.display = 'none';
                        // document.getElementById('<%=txt_Desc2.ClientID%>').style.display = 'none';
                    }
                    if (document.getElementById('<%=txt_Amount3.ClientID%>').value == 0) {
                        document.getElementById('<%=txt_Amount3.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Rate3.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Quantity3.ClientID%>').style.display = 'none';
                        //document.getElementById('<%=txt_Desc3.ClientID%>').style.display = 'none';
                    }
                    if (document.getElementById('<%=txt_Amount4.ClientID%>').value == 0) {
                        document.getElementById('<%=txt_Amount4.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Rate4.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Quantity4.ClientID%>').style.display = 'none';
                        //document.getElementById('<%=txt_Desc4.ClientID%>').style.display = 'none';
                    }}

                    if (RowCount == "3") {
                        var prtContent = document.getElementById(elementId);
                        var WinPrint = window.open('', '', 'left=1,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
                        document.getElementById('<%=txt_Amount2.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Amount1.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Amount3.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Rate1.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Rate2.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Rate3.ClientID%>').style.border = 0;
                       
                        document.getElementById('<%=txt_Quantity1.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Quantity2.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Quantity3.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Desc1.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Desc2.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Desc3.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Dated.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_OtherRef.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Remarks.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_InvoiceID.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_AmountInwords.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_BuyerOrTodetails.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_GrandTotal.ClientID%>').style.border = 0;
                        document.getElementById('<%=imgbtn_Search.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Tax12per.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Tax2per.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Tax1per.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_12percent.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_2percent.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_1percent.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Total.ClientID%>').style.border = 0;


                        if (document.getElementById('<%=txt_Amount2.ClientID%>').value == 0) {
                            document.getElementById('<%=txt_Amount2.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Rate2.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Quantity2.ClientID%>').style.display = 'none';
                        // document.getElementById('<%=txt_Desc2.ClientID%>').style.display = 'none';
                    }
                        if (document.getElementById('<%=txt_Amount3.ClientID%>').value == 0) {
                            document.getElementById('<%=txt_Amount3.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Rate3.ClientID%>').style.display = 'none';
                        document.getElementById('<%=txt_Quantity3.ClientID%>').style.display = 'none';
                        //document.getElementById('<%=txt_Desc3.ClientID%>').style.display = 'none';
                    }

                    }


                    if (RowCount == "2") {
                        var prtContent = document.getElementById(elementId);
                        var WinPrint = window.open('', '', 'left=1,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
                        document.getElementById('<%=txt_Amount2.ClientID%>').style.border = 0;
                        document.getElementById('<%=txt_Amount1.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Rate1.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Rate2.ClientID%>').style.border = 0;

                         document.getElementById('<%=txt_Quantity1.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Quantity2.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Desc1.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Desc2.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Dated.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_OtherRef.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Remarks.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_InvoiceID.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_AmountInwords.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_BuyerOrTodetails.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_GrandTotal.ClientID%>').style.border = 0;
                         document.getElementById('<%=imgbtn_Search.ClientID%>').style.display = 'none';
                         document.getElementById('<%=txt_Tax12per.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Tax2per.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Tax1per.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_12percent.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_2percent.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_1percent.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Total.ClientID%>').style.border = 0;


                         if (document.getElementById('<%=txt_Amount2.ClientID%>').value == 0) {
                             document.getElementById('<%=txt_Amount2.ClientID%>').style.display = 'none';
                            document.getElementById('<%=txt_Rate2.ClientID%>').style.display = 'none';
                            document.getElementById('<%=txt_Quantity2.ClientID%>').style.display = 'none';
                            // document.getElementById('<%=txt_Desc2.ClientID%>').style.display = 'none';
                        }
                         
                     }


                    if (RowCount == "1") {
                        
                        var prtContent = document.getElementById(elementId);
                        var WinPrint = window.open('', '', 'left=1,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
                        document.getElementById('<%=txt_Amount1.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Rate1.ClientID%>').style.border = 0;

                         document.getElementById('<%=txt_Quantity1.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Desc1.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Dated.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_OtherRef.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Remarks.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_InvoiceID.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_AmountInwords.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_BuyerOrTodetails.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_GrandTotal.ClientID%>').style.border = 0;
                         document.getElementById('<%=imgbtn_Search.ClientID%>').style.display = 'none';
                         document.getElementById('<%=txt_Tax12per.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Tax2per.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Tax1per.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_12percent.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_2percent.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_1percent.ClientID%>').style.border = 0;
                         document.getElementById('<%=txt_Total.ClientID%>').style.border = 0;

                     }

                    var docColor = "Black";
                    var strInnerHTML = prtContent.innerHTML;
                    var strModifiedInnerHTMl = strInnerHTML.replace(/white/g, docColor);
                    WinPrint.document.write(strModifiedInnerHTMl);
                    WinPrint.document.close();
                    WinPrint.focus();
                    WinPrint.print();
                    WinPrint.close();
                }
            
            // only numbers
            function onlynumber(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if ((charCode < 48 || charCode > 57) && (charCode != 8))
                    return false;
                return true;
            }

            //Only numbers with Decimals
            function onlynumberwithDecimals(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if ((charCode < 48 || charCode > 57) && (charCode != 8) && (charCode != 46))
                    return false;
                return true;
            }

            // calculating Amount1
            function calculate_Amount1(evt) {

                var Qunatity1 = parseFloat(document.getElementById('<%=txt_Quantity1.ClientID%>').value);
                var Rate1 = parseFloat(document.getElementById('<%=txt_Rate1.ClientID%>').value);
                //var SerTax = parseFloat(document.getElementById('<%=txt_12percent.ClientID%>').value);
                document.getElementById('<%=txt_Amount1.ClientID%>').value = (Qunatity1 * Rate1).toFixed(2);
                //var Total = parseFloat(document.getElementById('<%=txt_Amount1.ClientID%>').value);
                //document.getElementById('<%=txt_12percent.ClientID%>'.value) = ((Total*12)/100).toFixed(2);
                calculate_GrandTotal();
            }

            // calculating Amount2
            function calculate_Amount2(evt) {

                var Qunatity2 = parseFloat(document.getElementById('<%=txt_Quantity2.ClientID%>').value);
                var Rate2 = parseFloat(document.getElementById('<%=txt_Rate2.ClientID%>').value);
                document.getElementById('<%=txt_Amount2.ClientID%>').value = (Qunatity2 * Rate2).toFixed(2);
                calculate_GrandTotal();
            }

            // calculating Amount3
            function calculate_Amount3(evt) {

                var Qunatity3 = parseFloat(document.getElementById('<%=txt_Quantity3.ClientID%>').value);
                var Rate3 = parseFloat(document.getElementById('<%=txt_Rate3.ClientID%>').value);
                document.getElementById('<%=txt_Amount3.ClientID%>').value = (Qunatity3 * Rate3).toFixed(2);
                calculate_GrandTotal();
            }

            // calculating Amount4
            function calculate_Amount4(evt) {

                var Qunatity4 = parseFloat(document.getElementById('<%=txt_Quantity4.ClientID%>').value);
                var Rate4 = parseFloat(document.getElementById('<%=txt_Rate4.ClientID%>').value);
                document.getElementById('<%=txt_Amount4.ClientID%>').value = (Qunatity4 * Rate4).toFixed(2);
                calculate_GrandTotal();
            }
            // calculating Amount5


            // Calculating Grand Total
            function calculate_GrandTotal(evt) {

                var a1 = parseFloat(document.getElementById('<%=txt_Amount1.ClientID%>').value);
                var a2 = parseFloat(document.getElementById('<%=txt_Amount2.ClientID%>').value);
                var a3 = parseFloat(document.getElementById('<%=txt_Amount3.ClientID%>').value);
                var a4 = parseFloat(document.getElementById('<%=txt_Amount4.ClientID%>').value);
                var n = null;
                //var GrandTotal = 0;
                //GrandTotal = (a1 + a2 + a3 + a4 + a5).toFixed(2);
                if (a1 != n && a2 == n && a3 == n && a4 == n && a5 == n) {
                    document.getElementById('<%=txt_GrandTotal.ClientID%>').value = (a1).toFixed(2);
                }
                if (a2 != n) {
                    document.getElementById('<%=txt_GrandTotal.ClientID%>').value = (a1 + a2).toFixed(2);
                }
                if (a3 != n) {
                    document.getElementById('<%=txt_GrandTotal.ClientID%>').value = (a1 + a2 + a3).toFixed(2);
                }
                if (a4 != "") {
                    document.getElementById('<%=txt_GrandTotal.ClientID%>').value = (a1 + a2 + a3 + a4).toFixed(2);
                }
                var tax12per = document.getElementById('<%=txt_Tax12per.ClientID%>').value;
                var tax2per = document.getElementById('<%=txt_Tax2per.ClientID%>').value;
                var tax1per = document.getElementById('<%=txt_Tax1per.ClientID%>').value;

                var SerTax = document.getElementById('<%=txt_GrandTotal.ClientID%>').value;
                var EduCess = document.getElementById('<%=txt_12percent.ClientID%>').value;
                var SHEduCess = document.getElementById('<%=txt_2percent.ClientID%>').value;
                var heiTax = document.getElementById('<%=txt_1percent.ClientID%>').value;
                document.getElementById('<%=txt_12percent.ClientID%>').value = ((SerTax * tax12per) / 100).toFixed(2);
                document.getElementById('<%=txt_2percent.ClientID%>').value = ((EduCess * tax2per) / 100).toFixed(2);
                document.getElementById('<%=txt_1percent.ClientID%>').value = ((EduCess * tax1per) / 100).toFixed(2);
                var twelveper = document.getElementById('<%=txt_12percent.ClientID%>').value = ((SerTax * tax12per) / 100).toFixed(2);
                var twoper = document.getElementById('<%=txt_2percent.ClientID%>').value = ((EduCess * tax2per) / 100).toFixed(2);
                var oneper = document.getElementById('<%=txt_1percent.ClientID%>').value = ((EduCess * tax1per) / 100).toFixed(2);
                var add = parseFloat(SerTax) + parseFloat(twelveper) + parseFloat(twoper) + parseFloat(oneper);
                document.getElementById('<%=txt_Total.ClientID%>').value = Math.round((add).toFixed(2));
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divReport" runat ="server">
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
           
       <%-- <table style="height: 440px"  class ="tableline"  >--%>
             <table id="t1"  border="1"  rules="cols" frame="box" runat="server" >
            <tr style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;">
                <td style ="border :solid ;border-bottom-width :1px;border-top-width:0px;border-left-width :0px;border-right-width :0px;" >
                    <asp:DropDownList ID="ddl_particulars" runat="server" Height="25px" Width="100px">
                        <asp:ListItem>Particulars</asp:ListItem>
                        <asp:ListItem>Description</asp:ListItem>
                    </asp:DropDownList>
                    <div id="Div_Particulars"></div>
                    <asp:Label ID="lbl_Particulars" runat="server" Text="Label" Visible ="false" ></asp:Label>
                </td>
                <td class="style12">
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddl_QuantityorNooftrucks" runat="server" Height="25px" Width="100px">
                        <asp:ListItem>Quantity</asp:ListItem>
                        <asp:ListItem>No of Trucks</asp:ListItem>
                    </asp:DropDownList>
                    <div id="Div_Quantity"></div>
                    <asp:Label ID="lbl_Quantity" runat="server" Text="Label" Visible ="false" ></asp:Label>
                </td>
                <td class="style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Rate<br /> </td>
                <%--<td class="auto-style6">Per</td>--%>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount<br /> </td>
            </tr>
            <tr id ="tr1" runat="server" >
                
                <td class="auto-style2">
                    <asp:TextBox ID="txt_Desc1" runat="server" TextMode="MultiLine" Width="240px" Height ="50px" ></asp:TextBox>

                    <%--<asp:RequiredFieldValidator ID="rfq_BuyerorTo" runat="server" ControlToValidate="txt_BuyerOrTodetails" ErrorMessage="Enter Buyer or To Details" ValidationGroup="aarms"></asp:RequiredFieldValidator>--%>

                </td>
                <td class="auto-style4"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Quantity1" runat="server" Text ="0" Width="52px" style="text-align:right;" onchange="return calculate_Amount1(event)"  onkeypress="return onlynumber(event)" onkeyup="return calculate_Amount1(event)" ></asp:TextBox>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                </td>
                <td class="auto-style5"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Rate1" runat="server" style="text-align:right;" Text ="0" Width="50px" onchange="return calculate_Amount1(event)"  onkeypress="return  onlynumberwithDecimals(event)" onkeyup="return calculate_Amount1(event)" ></asp:TextBox>

                </td>
               <%-- <td class="auto-style6"> <asp:TextBox ID="TextBox35" runat="server" Width="74px"></asp:TextBox>

                </td>--%>
                <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Amount1" style="text-align:right;" runat="server" Text ="0" Width="65px" onchange="return calculate_GrandTotal(event)"   ></asp:TextBox>

                </td>
            </tr>
            <tr id ="tr2" runat="server" >
                <td class="auto-style2">
                    <asp:TextBox ID="txt_Desc2" runat="server" TextMode="MultiLine" Width="240px" Height ="50px" ></asp:TextBox>

                </td>
                <td class="auto-style4"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Quantity2" runat="server" style="text-align:right;" Width="52px" Text ="0"  onchange="return calculate_Amount2(event)"  onkeypress="return onlynumber(event)"  onkeyup="return calculate_Amount2(event)" ></asp:TextBox>

                </td>
                <td class="auto-style5"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Rate2" runat="server" style="text-align:right;" Width="50px"  Text ="0" onchange="return calculate_Amount2(event)"  onkeypress="return  onlynumberwithDecimals(event)" onkeyup="return calculate_Amount2(event)" ></asp:TextBox>

                </td>
               <%-- <td class="auto-style6"> <asp:TextBox ID="TextBox36" runat="server" Width="74px"></asp:TextBox>

                </td>--%>
                <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Amount2" runat="server" style="text-align:right;" Width="61px" Text ="0" onchange="return calculate_GrandTotal(event)" Height="22px"   ></asp:TextBox>

                </td>
            </tr>
            <tr id ="tr3" runat="server">
                <td class="auto-style2">
                    <asp:TextBox ID="txt_Desc3" runat="server" TextMode="MultiLine" Width="240px" Height ="50px" ></asp:TextBox>

                </td>
                <td class="auto-style4"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Quantity3" runat="server" style="text-align:right;"  Width="52px" Text ="0"  onchange="return calculate_Amount3(event)"  onkeypress="return onlynumber(event)" onkeyup="return calculate_Amount3(event)" ></asp:TextBox>

                </td>
                <td class="auto-style5"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Rate3" runat="server" style="text-align:right;" Width="50px"  Text ="0"  onchange="return calculate_Amount3(event)"  onkeypress="return  onlynumberwithDecimals(event)" onkeyup="return calculate_Amount3(event)" ></asp:TextBox>

                </td>
                <%--<td class="auto-style6"> <asp:TextBox ID="TextBox37" runat="server" Width="74px"></asp:TextBox>

                </td>--%>
                <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:TextBox ID="txt_Amount3" runat="server" style="text-align:right;" Width="65px" Text ="0" onchange="return calculate_GrandTotal(event)"  ></asp:TextBox>

                </td>
            </tr>
            <tr id ="tr4" runat="server" >
                <td class="auto-style2">
                    <asp:TextBox ID="txt_Desc4" runat="server" TextMode="MultiLine" Width="240px" Height ="50px" ></asp:TextBox>

                </td>
                <td class="auto-style4"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Quantity4" runat="server" style="text-align:right;" Width="52px" Text ="0" onchange="return calculate_Amount4(event)"  onkeypress="return onlynumber(event)" onkeyup="return calculate_Amount4(event)" ></asp:TextBox>

                </td>
                <td class="auto-style5"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:TextBox ID="txt_Rate4" runat="server" style="text-align:right;" Width="50px" Text ="0" onchange="return calculate_Amount4(event)"  onkeypress="return  onlynumberwithDecimals(event)" onkeyup="return calculate_Amount4(event)" ></asp:TextBox>

                </td>
                <%--<td class="auto-style6"> <asp:TextBox ID="TextBox38" runat="server" Width="74px"></asp:TextBox>

                </td>--%>
                <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_Amount4" runat="server" style="text-align:right;" Width="65px" Text ="0" onchange="return calculate_GrandTotal(event)"   ></asp:TextBox>

                </td>
            </tr>
            <tr>

                <td valign="top"  >
                    <br />
                    <br />
                    <asp:Label ID="lbl_ServiceTax" runat="server" Text="Service Tax @"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txt_Tax12per" runat="server" onchange="return calculate_Amount4(event)" onkeypress="return  onlynumberwithDecimals(event)" onkeyup="return calculate_Amount4(event)" Text="0" Width="25px"></asp:TextBox>
                    %
                    <br />
                    <br />
                    <asp:Label ID="lbl_EducationCess" runat="server" Text="Education Cess @"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txt_Tax2per" runat="server" onchange="return calculate_Amount4(event)" onkeypress="return  onlynumberwithDecimals(event)" onkeyup="return calculate_Amount4(event)" Text="0" Width="25px"></asp:TextBox>
                    %
                    <br />
                    <br />
                    <asp:Label ID="lbl_SHEducationCess" runat="server" Text="Secondary &amp; Higher Edu Cess @" Width ="220px" ></asp:Label>
                    <asp:TextBox ID="txt_Tax1per" runat="server" onchange="return calculate_Amount4(event)" onkeypress="return  onlynumberwithDecimals(event)" onkeyup="return calculate_Amount4(event)" Text="0" Width="15px"></asp:TextBox>
                    %</td>
                <td class="auto-style1"><br /> &nbsp;<br />
                    <br />
                </td>  
                <td>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td  valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total :&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_GrandTotal" runat="server" style="text-align:right;" Width="65px"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:TextBox ID="txt_12percent" runat="server" style="text-align:right;" Width="65px"></asp:TextBox>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:TextBox ID="txt_2percent" runat="server" style="text-align:right;" Width="65px"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txt_1percent" style="text-align:right;" runat="server" Width="65px"></asp:TextBox>
                </td>
            </tr>
                 <tr style ="border :solid ;border-bottom-width :0px;border-top-width:1px;border-left-width :0px;border-right-width :0px;" >
                     <td></td>
                     <td></td>
                     <td></td>
                     <td>
                         &nbsp;Grand Total :<asp:TextBox ID="txt_Total" runat="server" style="text-align:right;" AutoPostBack="true"  Width="65px"></asp:TextBox>
                     </td>
                 </tr>
        </table>
            &nbsp;Amount Chargeable (In words)<br />
            &nbsp;<asp:TextBox ID="txt_AmountInwords" runat="server" Font-Bold ="true"  Width="500px"></asp:TextBox>
            <br />
        
        <hr style="width: 730px; margin-left: 0px" />


            <%--&nbsp;PAN NO : AAICA2215Q<br /> &nbsp;SERVICE TAX REG. NO : AAICA2215QSD002<br /> &nbsp;BANK NAME : HDFC BANK<br /> &nbsp;BANK A/C NO : 08772560000251<br /> &nbsp;RTGS/NEFTIFC : HDFC0000877<br />--%>
              <asp:Panel ID ="Panel2" runat ="server" BorderStyle="Groove" style="margin-left: 309px" Width="394px" >
        <p style="text-align: center; margin-left: 58px;">
            For <asp:Label ID ="lbl_Name" Text ="AARMS VALUE CHAIN PRIVATE LIMITED" runat ="server" ></asp:Label></p><br />
        <p style="text-align: center; margin-left: 223px;">
            Authorised Signatory</p>
            </asp:Panel> 

  
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This is a Computer Generated Invoice
    </asp:Panel>
             </div>
            <p style="text-align: center">
             <asp:Button ID="btn_Update" runat="server" Text="Edit/Update" OnClick="btn_Update_Click" Enabled ="false" />
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" ValidationGroup ="aarms"  />
&nbsp;
               <input type ="button" value="Print" onclick="callPrint('divReport');" />
            <%--<asp:Button ID="btn_Print" runat="server" OnClientClick="callPrint('divReport');"  Text="Print" OnClick="btn_Print_Click" Enabled ="false" CssClass="hide" />--%>
                 &nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Reset" runat="server" Text="Reset" OnClick="btn_Reset_Click" />&nbsp; <asp:Button ID="btn_EditCalculations" runat="server" Text="ReCalculate" OnClick="btn_EditCalculationst_Click" />&nbsp;
                <asp:Button ID="btn_Report" runat="server" Text="Report" OnClick="btn_Report_Click" />
                <asp:Button ID="btn_BillPayment" runat="server" Text="Bill Payment" OnClick ="btn_BillPayment_Click"  />
         </p> 
<center><asp:Label ID ="lbl_Messsage" Text ="Once submitted then take print out" ForeColor ="red" runat ="server" ></asp:Label></center>

        <asp:Panel ID="pnl_Edit" runat="server" GroupingText ="Edit Bill"
                       CssClass ="ModalWindow">
            <table >
                <tr>
                    <td colspan ="2">
                        Enter Username And Password To Edit Bill
                    </td>
                </tr>
                <tr>
                    <td>
                        User Name :
                    </td>
                    <td>
                        <asp:TextBox ID ="txt_Username" runat ="server" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_Username" runat="server" 
                        ControlToValidate="txt_Username" ErrorMessage="*" ValidationGroup ="abc" ForeColor="Red"  ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password :
                    </td>
                    <td>
                        <asp:TextBox ID ="txt_Password" runat ="server" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_Password" runat="server" 
                        ControlToValidate="txt_Password" ErrorMessage="*" ValidationGroup ="abc" ForeColor="Red"    ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <center> <asp:Button id="btn_Edit" runat="server" ValidationGroup ="abc" text="Submit" OnClick="btn_Edit_Click" /> <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" /> </center>

                    </td>
                </tr>
            </table>

        </asp:Panel> 

    </div>
    </form>
</body>
</html>
