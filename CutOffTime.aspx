<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDashboardMenu.master" AutoEventWireup="true" CodeFile="CutOffTime.aspx.cs" Inherits="CutOffTime" %>
<%--<%@ Register Src="~/UserControl/DashboardMenuBar.ascx" TagName="Navihome" TagPrefix="menu" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagprefix="CC1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />

     <asp:ScriptManager ID ="scriptmanager1" runat ="server" ></asp:ScriptManager>
     <br />
     <div style="margin-left:150px"> 
    <table align="center" >
        <tr>
            <td>
                Travel Date :&nbsp;&nbsp;
            <asp:TextBox ID="txt_Traveldate" runat="server"></asp:TextBox>
                <CC1:CalendarExtender ID ="cal_Traveldate" runat ="server" TargetControlID ="txt_Traveldate"
                PopupButtonID ="imgdate1" ></CC1:CalendarExtender>
                <asp:ImageButton ID="imgdate1" runat="server" ImageUrl="~/images/cal.gif" Width="16px"/>
                <asp:RequiredFieldValidator ID="rfq_Traveldate" runat="server" ControlToValidate ="txt_Traveldate" ValidationGroup ="aarms" ErrorMessage="Enter Traveldate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
            <td>
                Earlier CuttOff Time :
            <%--<asp:TextBox ID="txt_Cuttofftime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfq_CuttoffTime" runat="server" ControlToValidate ="txt_Cuttofftime" ValidationGroup ="aarms" ErrorMessage="Enter CuttoffTime"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="Eddl_Hours" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>:<asp:DropDownList ID="Eddl_Minutes" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                </asp:DropDownList>&nbsp;<asp:DropDownList ID="Eddl_AMPM" runat="server">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
         <%--<tr>
            <td>
                CuttOff Time :
            <%--<asp:TextBox ID="txt_Cuttofftime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfq_CuttoffTime" runat="server" ControlToValidate ="txt_Cuttofftime" ValidationGroup ="aarms" ErrorMessage="Enter CuttoffTime"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="ddl_Hours" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>:<asp:DropDownList ID="ddl_Minutes" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddl_Ampm" runat="server">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td>  <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" ValidationGroup ="aarms" CausesValidation="true"  class="btn btn-primary"/>

            </td>
        </tr>
    </table>
              </div>

    <div style ="height:500px; width:100%; overflow:auto;">
             <asp:GridView ID="AdminGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" OnRowEditing="AdminGrid_RowEditing" OnRowUpdated="AdminGrid_RowUpdated" OnRowCancelingEdit="AdminGrid_RowCancelingEdit" OnRowUpdating="AdminGrid_RowUpdating" >
                 <Columns>
                     <asp:TemplateField HeaderText="PostID" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblpostid" runat="server" Text='<%#Eval("PostID")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Source" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblsource" runat="server" Text='<%#Eval("FromLocation")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Destination" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lbldestination" runat="server" Text='<%#Eval("ToLocation")%>'></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="BidStart Time" Visible="true">
                     <ItemTemplate>
                         <asp:Label ID="lblbid" runat="server" Text='<%#Eval("BidStartTime")%>'></asp:Label>
                      </ItemTemplate>
                         <EditItemTemplate>
                      <asp:TextBox ID="txt_bidstart" runat="server" Text='<%#Eval("BidStartTime")%>'></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="CutOff Time">
                     <ItemTemplate>
                         <asp:Label ID="lblcutoff" runat="server" Text='<%#Eval("AdditionalComments")%>'></asp:Label>
                      </ItemTemplate>
                       <EditItemTemplate>
                      <asp:TextBox ID="txt_cutoff" runat="server" Text='<%#Eval("AdditionalComments")%>'></asp:TextBox>
                      </EditItemTemplate>
                    </asp:TemplateField>

                     <asp:CommandField EditText="Edit" HeaderText="Action" ShowEditButton="True" />
                 </Columns>
                 <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                 <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                 <RowStyle BackColor="White" ForeColor="#330099" />
                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
             </asp:GridView>
         </div>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

