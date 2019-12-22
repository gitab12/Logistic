<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QuickView.aspx.cs" Inherits="QuickView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type ="text/css" >
       .style2
       {
           width: 282px;
           height: 21px;
       }
       .style3
       {
           height: 21px;
       }
        .style4
        {
            height: 21px;
            width: 183px;
        }

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <br /><br /><br /><br /><br /><br /> 
    
     <div style="margin-left:550px">
         <h2 class="title-one"> Quick View </h2></div>
    <br />
    <div style="margin-left:450px">
    <asp:radiobutton id ="rdb_CnNo" text="CollectionNoteNo" groupname="View" runat="server"></asp:radiobutton> <asp:radiobutton id ="rdb_ConfirmNo" groupname="View" text="ConfirmationNo" runat="server"></asp:radiobutton> <asp:radiobutton id ="rdb_BillNo" text="BillNo" groupname="View" runat="server"></asp:radiobutton>
    <br />
    Enter Number to search :  <asp:textbox id="txt_SearchNo" runat="server"></asp:textbox>  <asp:button id ="btn_Search" runat="server" text="Search" OnClick="btn_Search_Click" Class="btn btn-primary"/>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_Msg" ForeColor ="Red" Visible ="false" Font-Bold ="true"  runat="server" ></asp:Label>
    <br />   <br />
          </div>
         <div style="margin-left:250px">
     <div class ="mapouterdiv" >
          <div class ="mapinnerdiv" >
        <table align="center"  cellpadding="0"  
                cellspacing="0px"  width="100%" class="gridtable" >
                 <tr>
    <td align="left"  >
                                                        <table align="left" style="width: 100%;"  >
                                                            <tr>
                                                                <td class="style2" >
                                                                    ConfirmNo&nbsp;<br />
                                                                    <asp:TextBox ID="TxtCNconfirmno" runat="server" BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    <br />
                                                                    </td>
                                                                <td class="style3"  >
                                                                    CollectionNote No<br />
                                                                    <asp:TextBox ID="txtCNNumber" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                   </td>
                                                                <td class="style4"   >
                                                                    CollectionNote Date<br />
                                                                    <asp:TextBox ID="txtCNDate" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     <br />
                                                                    
</td>
                                                                <td class="style3">
                                                                    AutoNumber<br />
                                                                    <asp:TextBox ID="txtautonumber" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    <br />
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    Project No<br />
                                                                    <asp:TextBox ID="txtprojectno" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    WBS&nbsp; Number<br />
                                                                    <asp:TextBox ID="txtwbsno" runat="server" Enabled="false"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               <td class="style3">
                                                                    
                                                                     Description<br />
                                                                    <asp:TextBox ID="txtdescription" runat="server" Enabled="false"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    
                                                                    Transit Days<br />
                                                                    <asp:TextBox ID="txttransitdays" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     <br />
                                                                    
                                                                     </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="style3">
                                                                    From<br />
                                                                    <asp:TextBox ID="txtCNfrom" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> 
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    To<br />
                                                                    <asp:TextBox ID="txtCNTO" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Vehicle Type<br />
                                                                    <asp:TextBox ID="txtCNTruckType" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Vehicle Planned (nos)<br />
                                                                    <asp:TextBox ID="txtCNVehiclePlanned" runat="server" Enabled="false" BorderColor="Black" BorderStyle="Solid" 
                                                                             BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                                                                        
                                                            <tr>
                                                                <td class="style3">
                                                                    Length<br />
                                                                    <asp:TextBox ID="txtLength" runat="server" Enabled="false" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Width<br />
                                                                    <asp:TextBox ID="txtWidth" runat="server" Enabled="false" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Height<br />
                                                                    <asp:TextBox ID="txtHeight" runat="server" Enabled="false" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Total Weight<br />
                                                                    <asp:TextBox ID="txtTotalWeight" runat="server" Enabled="false"  BorderColor="Black" BorderStyle="Solid" 
                                                                             BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                                                                        
                                                            <tr>
                                                                <td class="style3">
                                                                    Consignor Name<br />
                                                                    <asp:TextBox ID="txtBuyer" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Consignor Contact Person<br />
                                                                    <asp:TextBox ID="txtContactPerson" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style3">
                                                                    Consignor Contact No<br />
                                                                    <asp:TextBox ID="txtContactNo" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                                     <td class="style3">
                                                                         Transporter<br />
                                                                    <asp:TextBox ID="txt_CliTransporter" runat="server"  BorderColor="Black" Enabled="false"
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                    

                                                                     </td>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Contract Price (A) <br />
                                                                     <asp:TextBox ID="txtCNBascicFreight" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Enabled="false" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Increase Price (B)<br />
                                                                     <asp:TextBox ID="txtApprovedPRice" runat="server"  Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                                                        onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Revised Price (A+B)<br />
                                                                     <asp:TextBox ID="txtNetPrice" runat="server" Enabled="false"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                                                        onkeypress="return onlynumber(event)" onkeyup="return calculation(event)" ReadOnly="true"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                         <br />
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Detention at Loading (charges)<br />
                                                                     <asp:TextBox ID="txtCNLoadingDetention" runat="server" Enabled="true"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Text ="0" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Detention at Unloading (charges) <br />
                                                                     <asp:TextBox ID="txtCNunloadingdetention" runat="server" Enabled="true"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Text ="0" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Loading Charges<br />
                                                                     <asp:TextBox ID="txtCNLoadingCharges" runat="server" Enabled="true"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Text ="0" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                         &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    Unloading Charges<br />
                                                                     <asp:TextBox ID="txtCNUNLoadingCharges" runat="server" Enabled="True"
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Text ="0" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    Octroi<br />
                                                                     <asp:TextBox ID="txtCNOctroid" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" Text ="0" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                    Dimension Difference<br />
                                                                     <asp:TextBox ID="txtCNDimensionDiff" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" Text ="0" BorderWidth="1px" onkeypress="return onlynumber(event)"  onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                                     <td class="style3">
                                                                    

                                                                       Other Claims<br />
                                                                     <asp:TextBox ID="txtCNOtherClaims" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" Text ="0" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    
  
                                                                    <asp:Label ID="lblless" runat="server" Font-Size="8pt" ForeColor="Red" 
                                                                        Text="LESS DEDUCTION"></asp:Label>
                                                                    
                                                                    </td>
                                                                <td class="style3">
                                                                    
                                                                        <asp:Label ID="Label4" runat="server" ForeColor="White"></asp:Label>
                                                                </td>
                                                               
                                                                <td class="style3">
                                                                    
                                                                  
                                                                     <td class="style3">
                                                                    

                                                                         &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    Insurance<br />
                                                                    <asp:TextBox ID="txtCNInsurance" runat="server" BorderColor="Black" Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                    

                                                                    
                                                                    <br />
                                                                    

                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    Damages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtCNDamages" runat="server"  BorderColor="Black" Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                </td>
                                                               
                                                                <td class="style4">
                                                                    Shortages<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtCNShortages" runat="server"  BorderColor="Black"  Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>
                                                                        
                                                                         <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Label"></asp:Label>
                                                                    
                                                                         </td>
                                                                     <td class="style3">
                                                                    

                                                                    OtherCharges<br />
                                                                    
                                                                    
                                                                    <asp:TextBox ID="txtCNOtherCharges" runat="server"  BorderColor="Black"  Text ="0"
                                                                        BorderStyle="Solid" BorderWidth="1px" onkeypress="return onlynumber(event)" onkeyup="return calculation(event)"></asp:TextBox>

                                                                    
                                                                     </td>
                                                            </tr>
                                                            
                                                           
                                                            
                                                            <tr>
                                                                <td  colspan ="4" class="td_bgcolor" align="center" style="color:Red" >
                                                                    &nbsp;Trip Details

                                                                 </td>
                                                            </tr>
                                                            
                                                                 <tr>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    Client 
                                                                    <br />
                                                                    <asp:TextBox ID="txtclient" runat="server" BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    Transporter<br />
                                                                    <asp:TextBox ID="txtTransporter" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                               
                                                                <td class="style4">
                                                                    <span >Assigned Date</span><br />  <asp:TextBox ID="txtassignedDate" runat="server" 
                                                                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    
                                                                     </td>
                                                                     <td class="style3">
                                                                    

                                                                    <span >From<br />
                                                                    <asp:TextBox ID="txtfrom" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                    </span>
                                                                     </td>
                                                            </tr>
                                                            
                                                                 <tr>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    To<br />
                                                                         <asp:TextBox ID="txtto" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                <td class="style3">
                                                                    

                                                                    
                                                                    Capacity<br />
                                                                    <asp:TextBox ID="txtcapacity" runat="server"  BorderColor="Black" 
                                                                        BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                               
                                                                <td class="style4">
                                                                    Truck type <br />
                                                                    <asp:TextBox ID="txttrucktype" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                                     <td class="style3">
                                                                    

                                                                    Enclosure Type<br />
                                                                    <asp:TextBox ID="txtEnclosure" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                     </td>
                                                            </tr>
                                                            <tr>
                                                                <td  colspan ="4" class="td_bgcolor" align="center" style="color:Red" >
                                                        Shipping Details</td>
                                                            </tr>
                                                                  <tr>
                                                                     <td colspan ="4">
                                                                     <asp:GridView ID="grd_Shipping" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="False" 
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <Columns>
                  <asp:BoundField DataField="CofirmNo" HeaderText="Cofirm No" />
                  <asp:BoundField DataField="ConfirmationDate" HeaderText="ConFirmationDate" />
                  <asp:BoundField DataField="TravelDate" HeaderText="TravelDate" />
                  <asp:BoundField DataField="VehicleNo" HeaderText="Vehicle No" />
                  <asp:BoundField DataField="DriverName" HeaderText="DriverName" />
                  <asp:BoundField DataField="LoadingStatus" HeaderText="LoadingStatus" />
                  <asp:BoundField DataField="LoadingTime" HeaderText="Loading Time" />
                  <asp:BoundField DataField="TripTime" HeaderText="Trip Time" />
                  <asp:BoundField DataField="LRNumber" HeaderText="LR Number" />
                  <asp:BoundField DataField="DeliveryDate" HeaderText="Delivery Date" />
                  <asp:BoundField DataField="ReceivedDate" HeaderText="Received Date" />
                  </Columns>
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
</td>

                                                            </tr>
															
															
															  <tr>
                                                                <td  colspan ="4" class="td_bgcolor" align="center" style="color:Red" >
                                                        Bill Status</td>
                                                            </tr>

                                                                   <tr>

                                                                      <td colspan ="4">
                                                                     <asp:GridView ID="GridView1" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="False" 
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <Columns>
                  <asp:BoundField DataField="CofirmNo" HeaderText="Confirm No" />
                  <asp:BoundField DataField="BillNo" HeaderText="Bill No" />
                  <asp:BoundField DataField="BillStatus" HeaderText="Status" />
                  <asp:BoundField DataField="ApprovalDate" HeaderText="Date" />
                  
                  </Columns>
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
</td>
                                                            


                                                                  <tr>
                                                                <td  colspan ="4" class="td_bgcolor" align="center" style="color:Red" >
                                                        Bill Submission</td>
                                                            </tr>

                                                                   <tr>

                                                                      <td colspan ="4">
                                                                     <asp:GridView ID="grd_BillSubmission" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="False" 
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <Columns>
                  <asp:BoundField DataField="Billconfirmno" HeaderText="Cofirm No" />
                  <asp:BoundField DataField="BillNo" HeaderText="BillNo" />
                  <asp:BoundField DataField="BillValue" HeaderText="Bill Value" />
                  <asp:BoundField DataField="BillSubmissionDate" HeaderText="Bill Date" />
                  <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                  </Columns>
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
</td>
                                                            </tr>

                                                                 <tr>
                                                                <td  colspan ="4" class="td_bgcolor" align="center" style="color:Red" >
                                                        Bill Payment</td>
                                                            </tr>

                                                                  <tr>

                                                                      <td colspan ="4">
                                                                     <asp:GridView ID="grd_BillPayment" runat="server" 
             CellPadding="4" ForeColor="#333333" Width="70%"
             EnableModelValidation="True" BorderStyle="None" AutoGenerateColumns="False" 
             >
       
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          
              <Columns>
                  <asp:BoundField DataField="paidConfirmno" HeaderText="Cofirm No" />
                  <asp:BoundField DataField="PaidBillNo" HeaderText="BillNo" />
                  <asp:BoundField DataField="PaymentAmount" HeaderText="Bill Payment Value" />
                  <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" />
                  <asp:BoundField DataField="ModeofPayment" HeaderText="Mode of Payment" />
                  <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No" />
                  <asp:BoundField DataField="ChequeDate" HeaderText="Cheque Date" />
                  <asp:BoundField DataField="PaidRemarks" HeaderText="Remarks" />
                  </Columns>
          
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="black" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
</td>
                                                            </tr>

                                                                 </table>
                                                    </td>
                     </tr> 
            </table> 
               </div> </div> 
             <br /><br /><br /><br /><br /><br />
        </div>
</asp:Content>

