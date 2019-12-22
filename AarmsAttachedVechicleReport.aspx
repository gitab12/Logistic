<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AarmsAttachedVechicleReport.aspx.cs" Inherits="AarmsAttachedVechicleReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br />
     <div style="margin-left:400px"><h2  class="title-one">Aarms Attached Vehicle Report</h2></div>
    <br /> 
    <div style="margin-left:550px"> 
    <asp:Button ID="ButDownload" runat="server" Text="Download To Excel" onclick="ButDownload_Click"  Class="btn btn-primary"/>
        </div>
    <br />
    <asp:Panel ID="AarmsVehicleReport" runat="server"  BorderColor="#0000" BorderStyle="Solid" Font-Bold="false" Height ="270px" ScrollBars="Auto" Width="73%" GroupingText="" Style="margin-left:10px">
    <asp:GridView ID="grd_AarmsVehicleReport" runat="server"  BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" >
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
     
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
        </asp:Panel>
    <br /><br /><br /><br />
</asp:Content>

