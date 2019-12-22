<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="MyTripplan.aspx.cs" Inherits="MyTripplan"  %>
<%@ Register Src="~/UserControl/TripPlanControl.ascx" TagName ="Trip" TagPrefix="UC1" %>
<%--<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagName="DashboardMenuBar" TagPrefix="Uc4" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
      <div class="row text-center clearfix">
								<div class="col-sm-8 col-sm-offset-3">	
<UC1:Trip id="Trip1" runat="server" />
</div>
          </div>
</asp:Content>

