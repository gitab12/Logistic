<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
         <asp:FileUpload ID="ExcelUpload" runat="server" />
    <asp:Button ID="btn_UploadAndDisplay" runat="server" 
       Text="Validate"  onclick="btn_UploadAndDisplay_Click1" />
  
    </form>
</body>
</html>
