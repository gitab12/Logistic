<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Report.aspx.cs" Inherits="Admin_Report" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   
    <br />  <br /> 
    <div class="container master-container" style=" padding-top: 66px;margin-left: 100px; ">
        <div class="panel panel-info">
         <div class="panel-heading" align="center"><h4>Admin Report</h4></div><br />
             <div class="panel-body">
         <div class="col-lg-12"> 
             <div class="panel-body">
                  <div class="form-horizontal" role="form">
            <div class="col-md-6" >
                <div class="form-group">
               <asp:Label ID="Lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="Green" Text="Label"></asp:Label>
                </div>
                    </div>
                 </div>
                      <div class="form-horizontal" role="form">
                 <div class="col-md-6">
                <div class="form-group">
                  <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel"  ValidationGroup="NewValidationGroup" class="btn btn-success center-block" OnClick="btnExportToExcel_Click" />
               </div>
           </div>
                          </div>
             </div>
             <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
			
           <div style ="height:500px; overflow:auto;">

             <asp:GridView ID="AdminGrid" runat="server"  AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" GridLines="Vertical" onrowediting="AdminGrid_RowEditing" onrowupdated="AdminGrid_RowUpdated"  onrowcancelingedit="AdminGrid_RowCancelingEdit" onrowupdating="AdminGrid_RowUpdating" >
                 <AlternatingRowStyle BackColor="#DCDCDC" />
              <Columns>
                  <asp:TemplateField HeaderText="UserID" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("UserID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="User Name" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblname" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="EmailID">
                     <ItemTemplate>
                         <asp:Label ID="lblemail" runat="server" Text='<%#Eval("EmailID")%>'></asp:Label>
                      </ItemTemplate>
                       <EditItemTemplate>
                      <asp:TextBox ID="txt_Email" runat="server" Text='<%#Eval("EmailID")%>'></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Password">
                     <ItemTemplate>
                         <asp:Label ID="lblpassword" runat="server" Text='<%#Eval("Password")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Company Name">
                     <ItemTemplate>
                         <asp:Label ID="lblcompname" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="WebSite URL">
                     <ItemTemplate>
                         <asp:Label ID="lblurl" runat="server" Text='<%#Eval("WebsiteUrl")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Mobile No.">
                     <ItemTemplate>
                         <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile")%>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                      <asp:TextBox ID="txtmobile" runat="server" Text='<%#Eval("mobile")%>'></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Phone No.">
                     <ItemTemplate>
                         <asp:Label ID="lblphone" runat="server" Text='<%#Eval("phone")%>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                      <asp:TextBox ID="txtphone" runat="server" Text='<%#Eval("phone")%>'></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Registration Date">
                     <ItemTemplate>
                         <asp:Label ID="lblregdate" runat="server" Text='<%#Eval("RegistrationDate")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>

                  <asp:CommandField EditText="Edit" HeaderText="Action" ShowEditButton="True" />




              </Columns>
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                 <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                 </asp:GridView>
				
                 </div>
				 
                 </div>
        </div>
        </div>

   </asp:Content> 
