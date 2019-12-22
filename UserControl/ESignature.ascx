<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ESignature.ascx.cs" Inherits="UserControl_ESignature" %>
  SignIn to ESignature
    <asp:TextBox ID="txtUserID" runat="server" value="Enter Email Id" 
                                    onblur="if(this.value=='') this.value='Enter Email Id';" 
                                    onfocus="if(this.value=='Enter Email Id') this.value='';"></asp:TextBox>
     
     
      <br />
     
     
     <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  value="Enter Password" 
                                    onblur="if(this.value=='') this.value='Enter Password';" 
                                    onfocus="if(this.value=='Enter Password') this.value='';"
     
     ></asp:TextBox>
     
      <br />
      <asp:Button ID="Butsubmit" runat="server" Text="Submit" class="btn" OnClick="Butsubmit_Click" />
        <br />
     <asp:TextBox ID="txtcode" runat="server"   value="Enter ESignCode" Visible="false"
                                    onblur="if(this.value=='') this.value='Enter ESignCode';" 
                                    onfocus="if(this.value=='Enter ESignCode') this.value='';"
     
     ></asp:TextBox>
   
  <%--    <a href="forgetpassword.aspx">Retrieve password</a></div>--%>
 
    
      <br />
      <asp:Button ID="ButSign" runat="server" Text="ESign" Visible="false" 
          onclick="ButSign_Click" />
 
    
      <br />
      
 <asp:Image ID="SignatureImage" runat="server"  Width="150px" Height="60px"   Visible="false" />
    

  <asp:Label ID="lblmsg" runat="server" Font-Names="Arial" ForeColor="Red"></asp:Label>