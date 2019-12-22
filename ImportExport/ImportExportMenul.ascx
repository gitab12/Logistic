<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportExportMenul.ascx.cs" Inherits="ImportExport_ImportExportMenul" %>
<style type ="text/css"  >
/*#trans-nav { list-style-type: none; height: 40px; padding: 0; margin: 0; }
#trans-nav li { float: left; position: relative; padding: 0; line-height: 40px; background: #5a8078 url(nav-bg.png) repeat-x 0 0; }
#trans-nav li:hover { background-position: 0 -40px; }
#trans-nav li a { display: block; padding: 0 15px; color: #fff; text-decoration: none; }
#trans-nav li a:hover { color: #a3f1d7; }
#trans-nav li ul { opacity: 0; position: absolute; left: 0; width: 11em; background: #63867f; list-style-type: none; padding: 0; margin: 0; }
#trans-nav li:hover ul { opacity: 1; }
#trans-nav li ul li { float: none; position: static; height: 0; line-height: 0; background: none; }
#trans-nav li:hover ul li { height: 30px; line-height: 30px; }
#trans-nav li ul li a { background: #63867f; }
#trans-nav li ul li a:hover { background: #5a8078; }*/

#trans-nav { list-style-type: none; height: 40px; padding: 0; margin: 0; }
#trans-nav li { float: left; position: relative; padding: 0; line-height: 30px; background: #C0C0C0 url(nav-bg.png) repeat-x 0 0; }
#trans-nav li:hover { background-position: 0 -40px; color : #C11B17; }
#trans-nav li a { display: block; padding: 0 15px; color: black; text-decoration: none;font-size :12.5px; }
#trans-nav li a:hover { color: white; }
#trans-nav li ul { opacity: 0; position: absolute; left: 0; width: 14em; background: #63867f; list-style-type: none; padding: 0; margin: 0; }
#trans-nav li:hover ul { opacity: 1; }
#trans-nav li ul li { float: none; position: static; height: 0; line-height: 0; background: none; }
#trans-nav li:hover ul li { height: 30px; line-height: 30px; }
#trans-nav li ul li a { background: #808080; }
#trans-nav li ul li a:hover { background: #837E7C; }

    </style>


  <ul id="trans-nav">
    <li><a href="#">Masters</a>
        <ul>
            <li><a href="../ImportExport/Agencies.aspx">Agency Master</a></li>
            <li><a href="../ImportExport/BuyerMaster.aspx">Buyer Master</a></li>
            <li><a href="../ImportExport/VendorMaster.aspx">Vendor Master</a></li>
        </ul>
    </li>
    <li><a href="#">Management</a>
        <ul>
            <li><a href="../ImportExport/OrderManagement.aspx">Po Management</a></li>
            <li><a href="../ImportExport/ImportExportInvoice.aspx">Invoice</a></li>
            <li><a href="../ImportExport/CustomDocument.aspx">Custom Document</a></li>
            <li><a href="../ImportExport/CHADeliveryChallan.aspx">CHA Challan Delivey</a></li>
        </ul>

    </li>
       
    <li><a href="#">Material</a>
       <%-- <ul>
            <li><a href="#">Widgets</a></li>
            <li><a href="#">Thingamabobs reports</a></li>
            <li><a href="#">Doohickies</a></li>
        </ul>--%>
    </li>
    <li><a href="#">Payment</a></li>
</ul>