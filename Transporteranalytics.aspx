<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Transporteranalytics.aspx.cs" Inherits="Transporteranalytics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     s<br /><br /><br /><br /><br /><br /> 
    <div style="margin-left:400px">
    <h2 class="title-one">Transport Analysis Report</h2>
        </div>
     <div style="margin-left:450px">
       <table>
           <tr>
               <td>
               <asp:RadioButton ID="rad_monthwise" runat="server" Checked="true" Text="MonthWise" GroupName="a" AutoPostBack="true" OnCheckedChanged="rad_monthwise_CheckedChanged" />
                   </td>
               <td>
               <asp:RadioButton ID="rad_Daywise" runat="server"  Text="DayWise" GroupName="a"   AutoPostBack="true" OnCheckedChanged="rad_Daywise_CheckedChanged"/>
                   </td>
           </tr>
<tr>
<td>
    <asp:DropDownList ID="SelectMonth" runat="server"  Width="134px" Height="25px">

<asp:ListItem Value="0">Select Month</asp:ListItem>
<asp:ListItem Value="1">January</asp:ListItem>
<asp:ListItem Value="2">February</asp:ListItem>
<asp:ListItem Value="3">March</asp:ListItem>
<asp:ListItem Value="4">April</asp:ListItem>
<asp:ListItem Value="5">May</asp:ListItem>
<asp:ListItem Value="6">June</asp:ListItem>
<asp:ListItem Value="7">July</asp:ListItem>
<asp:ListItem Value="8">August</asp:ListItem>
<asp:ListItem Value="9">September</asp:ListItem>
<asp:ListItem Value="10">October</asp:ListItem>
<asp:ListItem Value="11">November</asp:ListItem>
<asp:ListItem Value="12">December</asp:ListItem>

      </asp:DropDownList>
    <br />
    <asp:TextBox ID="txtFrom" runat="server" Visible="false"></asp:TextBox>
        

    
    </td>
    <td>
        &nbsp;&nbsp;
    <asp:DropDownList ID="SelectYear" runat="server"  Width="75px" Height="25px">
	 <asp:ListItem Value="2018">2018</asp:ListItem> 
        <asp:ListItem Value="2017">2017</asp:ListItem>  
<asp:ListItem Value="2016">2016</asp:ListItem>      
<asp:ListItem Value="2015">2015</asp:ListItem>


</asp:DropDownList>
          <br />
          <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Width="16px" Visible="false" />
          
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server"  PopupButtonID="imgdate1" TargetControlID="txtFrom">                
    </ajaxtoolkit:calendarextender>
    </td>
<td>&nbsp;&nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit"  OnClick="btnSubmit_Click"    class="btn btn-primary" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="Button1" runat="server" Text="Download" onclick="Button1_Click"  class="btn btn-primary"  /></td>
</tr>
</table>
         </div>

     <asp:Panel ID="pnl_TransportAnalysis" runat="server"  BorderColor="#0000" BorderStyle="Solid" Height="370px" Width="800px" ScrollBars="Auto"  Style="margin-left:250px" >
    <asp:GridView ID="grd_TransportAnalysis" runat="server" BorderColor="Black"  BackColor="White" GridLines="Both" 
    CellPadding="4" ForeColor="#333333" 
         AutoGenerateColumns="True">
    <RowStyle BackColor="White" ForeColor="#333333" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#B70808" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    </asp:Panel>
     <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

