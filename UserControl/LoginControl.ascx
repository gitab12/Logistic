<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs" Inherits="UserControl_LoginControl" %>
<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="login" %>
<%@ Register Src="~/UserControl/WelcomeControl.ascx" TagPrefix="ucw" TagName="welcome" %>
<link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/>
<ucw:welcome runat="server" ID="welcome1" />
<uc1:login runat="server" ID="login1" />
